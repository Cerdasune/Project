using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public GameObject[] enemyspawner;
    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for (int i =0;1 < enemyspawner.Length; i++)
            {
                enemyspawner[i].SetActive(true);
                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.SpawnEnemyFields();
        }
    }


}
