using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public GameObject player;

    public float forwardDistance1 = 50f;
    public float forwardDistance2 = 75f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x+ forwardDistance1)
        {
            transform.position = new Vector3(player.transform.position.x+ Random.Range(forwardDistance1, forwardDistance2), transform.position.y,transform.position.z);
        }
    }
}
