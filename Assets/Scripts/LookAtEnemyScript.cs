using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemyScript : MonoBehaviour
{
    private PlayerController player;

    public Transform Player;

    public float visionAngle = 1f;
    public float visionDistance = 1f;
    public float moveSpeed = 1f;
    public float chaseDistance = 2f;

    public float speed = 1f;
    public float timer;
    public float timeToTurn = 3f;


    // Use this for initialization
    void Start()
    {
        int dir = Random.Range(0, 2);
        print(dir);

        if (dir == 0)
        {
            speed = -speed;
        }

        else
        {
            speed = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = Player.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);

        //timer += Time.deltaTime;
        //transform.position = transform.position + Vector3.right * speed * Time.deltaTime;

        if (timer > timeToTurn)
        {
            speed = -speed;
            timer = 1f;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakingHit();
            Destroy(gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        speed = -speed;
    }

}











