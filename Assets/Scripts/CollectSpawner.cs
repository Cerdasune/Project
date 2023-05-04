using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawner : MonoBehaviour
{
    public GameObject[] movingcollectable;
    public float spawnTimer = 3;
     

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(movingcollectable[Random.Range(0,3)], transform.position, transform.rotation);
        spawnTimer = Random.Range(1, 10);
        Invoke("Spawn", spawnTimer);

    }
}