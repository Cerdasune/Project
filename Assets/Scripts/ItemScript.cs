using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject Player;
   

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().Collectcake();
            print("kakku");
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().Collectbread();
            print("leip�");
            Destroy(gameObject);
        }

        /*
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().SpeedUp();
            other.gameObject.GetComponent<Player>().Collectdrink();
            print("juoma");
            Destroy(gameObject);
        }
        */

        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().NewLife();
            other.gameObject.GetComponent<Player>().Collectheart();
            print("syd�n");
            Destroy(gameObject);
        }

        if(other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }

       
    }

}
