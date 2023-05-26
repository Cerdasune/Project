using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform target;
    public GameObject enemybullet;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        Destroy(gameObject, 15f);
    }

    public void Shoot()
    {
        Instantiate(enemybullet, transform.position, transform.rotation);

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
