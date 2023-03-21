using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*bulletSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
