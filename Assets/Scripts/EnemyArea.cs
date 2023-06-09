using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public GameObject[] enemyspawner;
    public GameObject[] enemyspawner2;
    public GameObject[] enemyspawner3;

    public GameObject[] enemyFields;
    public GameObject[] enemyFields2;

    public int Level; 

    public GameManager gm;

    public int enemyEncounters;

    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(enemyEncounters < 3)
            {
                for (int i = 0; i < enemyspawner.Length; i++)
                {
                    Instantiate(enemyFields[Random.Range(0, enemyFields.Length)], enemyspawner[i].transform.position, transform.rotation);

                }
            }

            if (enemyEncounters >= 3)
            {
                for (int i = 0; i < enemyspawner2.Length; i++)
                {
                    Instantiate(enemyFields[Random.Range(0, enemyFields.Length)], enemyspawner2[i].transform.position, transform.rotation);

                }
            }

            transform.position = new Vector3(transform.position.x + 60f, transform.position.y, transform.position.z);
            enemyEncounters++;
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.SpawnEnemyFields();
        }
    }
*/
    private void Update()
    {

    }

}
