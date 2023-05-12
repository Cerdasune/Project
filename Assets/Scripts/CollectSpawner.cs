using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawner : MonoBehaviour
{
    public GameObject[] movingcollectable;
    public float spawnTimer = 6;
     

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(movingcollectable[Random.Range(0,3)], new Vector3(transform.position.x + 12, transform.position.y + 3, transform.position.z), transform.rotation);
        spawnTimer = Random.Range(10, 15);
        Invoke("Spawn", spawnTimer);

    }
}
