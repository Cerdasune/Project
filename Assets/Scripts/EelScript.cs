using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelScript : MonoBehaviour
{
    public float speed = 3f;



    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime); 
    }
}
