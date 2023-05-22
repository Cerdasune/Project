using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Gamemode")]
    public bool twinstick = false;
    public bool mouseaim = false;
    public bool classic = false;
   
    

    [Header("Player movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 20f;
    public float hor;
    public float ver;
    // public float dep;
    public float rotation;


    [Header("Shooting")]
    public GameObject bullet;
    public GameObject capsule;
    public GameObject lazer;
    public Transform gun;
    public float fireRate = 0.5f;
    public bool canFire = true;





    // Start is called before the first frame update
    void Start()
    {
        if(twinstick)
        {
            gun.GetComponent<TwinstickAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }

        else if(classic)
        {
            gun.GetComponent<TwinstickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //dep = Input.GetAxis("Depth"); //this is optional, if not used transform last part, 0


        //This is for moving the player

        if (hor == 0)
        {
            transform.Translate(new Vector3( 1 * Time.deltaTime, ver * playerSpeed * Time.deltaTime, 0));

        }

        else 
        {
            transform.Translate(new Vector3(hor * playerSpeed * Time.deltaTime, ver * playerSpeed * Time.deltaTime, 0));

        }

        
        //this is for shooting

        if (!twinstick && Input.GetButtonDown("Jump") && canFire)
        {
            Shoot();
            //StartCoroutine("Shoot");

        }

        if (Input.GetButton("Fire1"))
        {
            Shootrapidly();

        }

        if (Input.GetButton("Fire2"))
        {
            Shootlazer();

        }

    }

    public void Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);


    }
    

    public void Shootrapidly()
    {
        Instantiate(capsule, gun.position, gun.rotation);

    }

    public void Shootlazer()
    {
        Instantiate(lazer, gun.position, gun.rotation);

    }

    //this is if you want to control the time how often the player can shoot (either this or regular public void shoot)

    public IEnumerator Shoottwinstick()
    {
        Instantiate(bullet, gun.position, gun.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }


}
