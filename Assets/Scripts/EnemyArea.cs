using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AsteroidArea : MonoBehaviour
{
    public GameObject[] spawner1;


    public GameManager gameManager;

    public GameObject diamond;
    public GameObject bread;
    public GameObject cake;
    public GameObject Drink;

    private void Start()
    {
        gameManager = GameObject.Find("GM").GetComponent<GameManager>();

        int rnd = Random.Range(0, 2);

        if (rnd == 1)
        {
            Instantiate(diamond, transform.position, transform.rotation);

        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "Player")
        {

            for (int i = 0; i < spawner1.Length; i++)
            {

                spawner1[i].SetActive(true);
            }

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameManager.SpawnEnemyFields();
        }
    }


}

