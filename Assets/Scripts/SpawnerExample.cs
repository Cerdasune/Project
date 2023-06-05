using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExample : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacle, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
