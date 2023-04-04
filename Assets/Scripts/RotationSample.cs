using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSample : MonoBehaviour
{
    [Range(5f, 100f)]
    public float drivingSpeed = 5f;
    [Range(10f,100f)]
    public float rotateSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = new Quaternion(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    { 

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * ver * drivingSpeed * Time.deltaTime);
        transform.Rotate( Vector3.up * hor * rotateSpeed * Time.deltaTime);
    }
}
