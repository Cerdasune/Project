using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaScript : MonoBehaviour
{
    public GameObject[] enemySpawn;

    public GameManager gm;

    public GameObject[] collectable;

    public GameObject[] treeSpawner;

    public float spawnTimer = 6;

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();

        int rnd = Random.Range(0, 5);

        if(rnd == 1)
       {
            Instantiate(collectable[1], transform.position, transform.rotation);

       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")

            for (int i = 0; i < enemySpawn.Length; i++)
            {
                enemySpawn[i].SetActive(true);

            }

       /* if (other.gameObject.name == "Player")

            for (int i = 0; i < enemySpawn.Length; i++)
            {
                Instantiate(treeSpawner[Random.Range(0, 3)], new Vector3(transform.position.x + 12, transform.position.y, transform.position.z), transform.rotation);
                spawnTimer = Random.Range(10, 15);
                Invoke("Spawn", spawnTimer);
                treeSpawner[i].SetActive(true);
            }
       */

        if (other.gameObject.name == "Treeobject")

            for (int i = 0; i < enemySpawn.Length; i++)
            {
                Instantiate(treeSpawner[Random.Range(0, 3)], new Vector3(transform.position.x + 12, transform.position.y, transform.position.z), transform.rotation);
                spawnTimer = Random.Range(0,1);
                Invoke("Spawn", spawnTimer);
                //treeSpawner[i].SetActive(true);
                print("I spawned a tree");
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            gm.SpawnEnemyFields();
            gm.Spawntrees();
        }
    }

}
