using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
          gameManager = this.gameObject;
        }

        else
        {
          
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
    
      

   
    
}
