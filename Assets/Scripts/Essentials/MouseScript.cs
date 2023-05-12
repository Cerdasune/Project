using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

    public LayerMask layerMask;


    //this code is for mouse aiming
    private void FixedUpdate()
    {
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(myray, out hit, Mathf.Infinity, layerMask))
        {
            //this code is to move object smoothly on the surface with cursor
            transform.position = Vector3.Lerp(transform.position, hit.point, 0.1f);

            //this code is for destroying the objects with cursor
            //if(Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy"))
           // {
                //Destroy(hit.transform.gameObject);

            }
        { 

            //you cannot use both of the commands at the same time. either aim or move your object with code
        }

        Debug.DrawRay(Camera.main.transform.position, Vector3.forward, Color.green, 1000f);
    }
}
