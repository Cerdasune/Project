using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;

    public int levelScore;

    public LevelScoreScript levelscoreScript;

    public GameObject Score;
    public GameObject youWin;
    

    public TextMeshProUGUI hiScoreText;

    public int maxScore;

    public static int hiScore;

    public AudioSource titleMusic;

    public GameObject[] enemyFields;

    public GameObject[] enemyFields2;

    public GameObject player;

    public GameObject gameOverMenu;
    public GameObject menuButton;
    public GameObject retryButton;
   

    public Animator fadescreen;
    public float transitionTime = 3f;

    public static GameManager gameManager;

    public GameObject winWall;

   

 
    // Start is called before the first frame update
    void Start() 
    {
       score = 0;
       hiScore = PlayerPrefs.GetInt("HiScore");
       hiScoreText.text = "Hi Score" + hiScore.ToString();

        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

        else if(gameManager != this)
        {
            Destroy(gameObject);
        }
 
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelscoreScript = GameObject.Find("LevelScore").GetComponent<LevelScoreScript>();
        player = GameObject.Find("Player");
        player.GetComponent<Player>().gm = gameObject.GetComponent<GameManager>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        print("Score set");
        Score = GameObject.Find("Score");
        youWin = GameObject.Find("StageClear");
        gameOverMenu = GameObject.Find("GameOver");
        menuButton = GameObject.Find("ExitButton (1)");
        retryButton = GameObject.Find("Retry");

        youWin.SetActive(false);
        fadescreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
        gameOverMenu.SetActive(false);
        //StartCoroutine("DisableMenu");

    }

    public IEnumerator DisableMenu()
    {
        yield return new WaitForSeconds(0.1f);
        gameOverMenu.SetActive(false);
    }


    //Scoresystem

    public void AddScore( int newScore)
    {
        score += newScore;

    }

    public void UpdateScore()
    {
        scoreText.text = "Score 0" + levelscoreScript.levelScore;
    }

    void Update()
    {
       

        UpdateScore();

        if(score == maxScore)
        {
            Score.SetActive(false);
            //youWin.SetActive(true);
            //StartCoroutine(Loadlevel(2));

        }
    }

    public void StartGame()
    {
        StartCoroutine(Loadlevel(1));
        titleMusic.Stop();
    }

    public IEnumerator Loadlevel(int levelToLoad)
    {
        fadescreen.SetTrigger("ChangeLevel");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelToLoad);

    }
    public void retry()
    {

        StartCoroutine(Loadlevel(1));
    }

    public void Quit()
    {
        StartCoroutine(Loadlevel(0));
    }

    public void Scorecounterinscreen()
    {
        //score += 10;
        //hiScoreText.text = "Score" + score.ToString();

        if(score > hiScore)
        {
            hiScore = score;
            //hiScoreText.text = "Hi Score" + hiScore.ToString();
            PlayerPrefs.SetInt("Hi Score", hiScore);
            PlayerPrefs.Save();
        }
    }

    public void SpawnEnemyFields()
    {
        int rnd = Random.Range(0,3);
        Instantiate(enemyFields[rnd], new Vector3(player.transform.position.x+60, player.transform.position.y, player.transform.position.z), player.transform.rotation);
    }

    public void SpawnEnemyFieldsLevel2()
    {
        int rnd = Random.Range(0, 2);
        Instantiate(enemyFields2[rnd], new Vector3(player.transform.position.x + 60, player.transform.position.y, player.transform.position.z), player.transform.rotation);
    }

    public void ClearData() //doesn't do anything, since it needs Clear data-button to work.
    {
        PlayerPrefs.SetInt("HiScore", 0);
        hiScore = PlayerPrefs.GetInt("HiScore");
       // hiScoreText.text = "Hi Score" + hiScore.ToString();
        PlayerPrefs.Save();

    }

  

    public void StageClear()
    {
        youWin.SetActive(true);
        Time.timeScale = 0f;
        GameObject.Find("Player").SetActive(false);
        print("I found player");
        retryButton.SetActive(true);
        menuButton.SetActive(true);
        Destroy(gameObject);
    }


    public void Win()
    {
        StartCoroutine(Loadlevel(4));    
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
