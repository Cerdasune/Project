using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemyScript : MonoBehaviour
{
    private PlayerController player;

    public Transform Player;

    public GameObject enemyEffect;

    public float visionAngle = 10f;
    public float visionDistance = 10f;
    public float moveSpeed = 10f;
    public float chaseDistance = 20f;

    public float speed = 10f;
    public float timeToTurn = 3f;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lookAt = Player.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakingHit();
            Instantiate(enemyEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }

}











