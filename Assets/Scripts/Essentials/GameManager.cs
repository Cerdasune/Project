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

    public GameObject Score;
    public GameObject youWin;

    public TextMeshProUGUI hiScoreText;

    public int maxScore;

    public static int hiScore;

    public AudioSource titleMusic;

    public GameObject[] enemyFields;
    public GameObject player;
   

    public Animator fadescreen;
    public float transitionTime = 3f;

    public static GameManager gameManager;

 
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

 

    //Scoresystem

    public void AddScore( int newScore)
    {
        score += newScore;

    }

    public void UpdateScore()
    {
        scoreText.text = "Score 0" + score;
    }

    void Update()
    {
       

        UpdateScore();

        if(score == maxScore)
        {
            Score.SetActive(false);
            youWin.SetActive(true);
            StartCoroutine(Loadlevel(2));

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
            hiScoreText.text = "Hi Score" + hiScore.ToString();
            PlayerPrefs.SetInt("Hi Score", hiScore);
            PlayerPrefs.Save();

        }

    }

    public void SpawnEnemyFields()
    {
        int rnd = Random.Range(0,5);
        Instantiate(enemyFields[rnd], new Vector3(player.transform.position.x+30, player.transform.position.y, player.transform.position.z), player.transform.rotation);
    }

    public void ClearData() //doesn't do anything, since it needs Clear data-button to work.
    {
        PlayerPrefs.SetInt("HiScore", 0);
        hiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.text = "Hi Score" + hiScore.ToString();
        PlayerPrefs.Save();

    }

    public void GameOver()
    {
        

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
