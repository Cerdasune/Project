using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{

    public GameObject enemyBullet;
    public GameObject enemyEffect;
    public Transform target;

    public GameObject HealthbarUI;
    public Slider slider;

    public float health;

    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();

        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            HealthbarUI.SetActive(true);
        }

        if (health <= 0)
        {
            Instantiate(enemyEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakingHit();
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}















