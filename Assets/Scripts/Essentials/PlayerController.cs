using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player movement")]
    [Range(0.1f,30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    // public float dep;

    
    [Header ("Shooting")]
    public GameObject bullet;
    public GameObject capsule;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //dep = Input.GetAxis("Depth"); //this is optional, if not used transform last part, 0


        //This is for moving the player
        transform.Translate(new Vector3(hor * playerSpeed * Time.deltaTime, ver * playerSpeed * Time.deltaTime,0));

        //this is for shooting

        if(Input.GetButtonDown("Jump"))
        {
            Shoot();

        }

        if (Input.GetButton("Fire1"))
        {
            Shootrapidly();

        }

    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);

    }

    public void Shootrapidly()
    {
        Instantiate(capsule, transform.position, transform.rotation);

    }
}
