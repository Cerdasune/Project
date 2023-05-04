using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaScript : MonoBehaviour
{
    public GameObject[] enemySpawn;

    public GameManager gm;

    public GameObject[] collectable; 

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();

        int rnd = Random.Range(0, 5);

        if(rnd == 1)
        {
            Instantiate(collectable[rnd], transform.position, transform.rotation);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")

            for (int i = 0; i < enemySpawn.Length; i++)
            {
                enemySpawn[i].SetActive(true);

            }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            gm.SpawnEnemyFields();

        }
    }
}
