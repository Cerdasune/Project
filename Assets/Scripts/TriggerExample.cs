using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    public GameManager gm;
    public GameObject treasure;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            //gm.Scorecounterscreen();
            Instantiate(treasure, new Vector3(transform.position.x, transform.position.y+15, transform.position.z), transform.rotation);

        }
    }
}
