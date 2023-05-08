using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    public GameManager gm;
    public GameObject[] movingcollectable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
            gm.Scorecounterinscreen();
            Instantiate(movingcollectable[Random.Range(0, 3)], new Vector3(transform.position.x+12,transform.position.y,transform.position.z), transform.rotation);

        }
    }
}
