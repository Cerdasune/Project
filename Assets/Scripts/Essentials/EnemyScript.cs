using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject enemyBullet;
    public Transform target;

    //public float enemySpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //InvokeRepeating("Shoot", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        //transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        //Instantiate(enemyBullet, transform.position, transform.rotation);
        Destroy(gameObject, 20f);
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