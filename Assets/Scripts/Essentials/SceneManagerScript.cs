using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManagerScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject InventoryMenu;

    public bool paused = false;

    public Animator UIAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Openpause()
    {
        pauseMenu.SetActive(true);

    }

    public void Inventory()
    { 
        InventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Openwindow()
    {
        Time.timeScale = 0f;
        UIAnimator.SetTrigger("Open");

    }

    public void Closewindow()
    {
        
        pauseMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        UIAnimator.SetTrigger("Close");
        Time.timeScale = 1f;
    }

}

