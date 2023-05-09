using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExample : MonoBehaviour
{
    public Transform target;
    public float delay = 1;

    public Camera[] cameras;
    public GameObject[] postEffects;
    public GameObject ui; 


    // Start is called before the first frame update
    void Start()
    {
        cameras[1].enabled = false;

        postEffects[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, target.position, delay * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.H))
        {
            DisableCameras();
            cameras[1].enabled = true;
            postEffects[1].SetActive(true);
            ui.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            DisableCameras();
            cameras[2].enabled = true;
            postEffects[2].SetActive(true);
            ui.SetActive(false);



        }

    }

    public void DisableCameras()
    {
      for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
            postEffects[i].SetActive(false);

        }
      


    }
}
