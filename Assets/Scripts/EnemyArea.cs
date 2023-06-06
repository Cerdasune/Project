using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public GameObject[] enemyspawner;

    public int Level; 

    public GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for (int i =0;1 < enemyspawner.Length; i++)
            {
                enemyspawner[i].SetActive(true);

                if(Level == 1)
                {
                    gm.SpawnEnemyFields();

                }

                else if(Level == 2)
                {
                    gm.SpawnEnemyFieldsLevel2();

                }
               


            }

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
        Destroy(gameObject, 40f);
    }

}
