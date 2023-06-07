using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelScript : MonoBehaviour
{
    public float speed = 3f;



    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, -90, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }
}
