using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyScript : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 30f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakingHit();
            Destroy(gameObject);
        }
    }
}

