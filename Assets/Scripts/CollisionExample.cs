using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{
    public GameObject retrybutton;
    public GameObject explosion;
    public GameObject backbutton;

    public Animator cameraAnim;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            StartCoroutine(HitStop());

        }
    }
    
    public IEnumerator HitStop()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        Instantiate(explosion, transform.position, transform.rotation);
        //cameraAnim.SetTrigger("Shake");
        GameObject.Find("Player").SetActive(false);
        yield return new WaitForSeconds(0.5f);
        retrybutton.SetActive(true);
        backbutton.SetActive(true);
        Destroy(gameObject);


    }
}
