using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxhealth = 10;
    [SerializeField] private float _currenthealth;
    [SerializeField] private float _healthIncrease = 2f;
    [SerializeField] private GameObject _deathEffect, _hitEffect;

    [SerializeField] private float _magicplus = 10;
    private float _currentmagic = 0f;

    private float _currentScore = 0;

    public int lives;

    [SerializeField] private HealthBar _healthbar;
    [SerializeField] private MagicBarScript _magicbar;
    public GameObject gameOverScreen;
    public GameManager gm;

    public float PlayerSpeed = 20f;
    public float originalSpeed;
    public float maxSpeed = 50f;

    public int heartsCollected = 0;
    public int cakesCollected = 0;
    public int drinksCollected = 0;
    public int breadsCollected = 0;

    public TextMeshProUGUI breadtext;
    public TextMeshProUGUI drinktext;
    public TextMeshProUGUI caketext;
    public TextMeshProUGUI hearttext;

    public AudioSource itemSound;

    public GameObject Speedeffect;
    public GameObject Lifeeffect;
    public GameObject Magiceffect;
    public GameObject Energyeffect;


    // Start is called before the first frame update
    void Start()
    {
        PlayerSpeed = originalSpeed;
        _currenthealth = _maxhealth;
        //_healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
        _magicbar.UpdateMagicbar(_currentmagic);
        _currentScore = 0;
    }

    // Update is called once per frame
    public void TakingHit()
    {
        _currenthealth -= Random.Range(0.5f, 1.5f);

        if (_currenthealth <= 0)
        {
            if(lives > 0)
            {
                _currenthealth = 10f;
                _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
                lives--;
            }

            else
            {
                Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
            }

        }

        else
        {
            _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
            Instantiate(_hitEffect, transform.position, Quaternion.identity);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MagicItem")
        {
            _magicbar.UpdateMagicbar(_magicplus);
            gm.score = gm.score+ 10;
            print("I got magic");
            StartCoroutine("MagicUp");
            itemSound.Play();
        }

        if (other.gameObject.tag == "SpeedItem")
        {
            GetComponent<PlayerController>().playerSpeed = GetComponent<PlayerController>().playerSpeed * 1.5f;
            gm.score = gm.score + 15;
            print("I got speed");
            itemSound.Play();
            StartCoroutine("SpeedUp");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "HealthItem")
        {
            print("I got health");
            _currenthealth += _healthIncrease;
            _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
            gm.score = gm.score + 20;
            StartCoroutine("EnergyUp");
            itemSound.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "LifeItem")
        {
            lives++;
            gm.score = gm.score+ 40;
            print("I got life");
            StartCoroutine("LifeUp");
            itemSound.Play();
        }

        if (other.gameObject.tag == "StageWall")
        {
            gm.StageClear();
            
        }
           
    }

    /*
   public void MagicUp()
    {
        _magicbar.UpdateMagicbar(-_maxmagic, _currentmagic);
    }
    */


    public void NewLife()
    {
        
    }


  
   void Update()
    {
        caketext.text = "Cake " + cakesCollected;
        breadtext.text = "Bread " + breadsCollected;
        drinktext.text = "Drink " + drinksCollected;
        hearttext.text = "Heart " + heartsCollected;
    }
  

    //Item collecting,catalog and using the item from the menu

    public void Collectcake()
    {
        cakesCollected++;    
    }

    public void Usecake()
    {
        cakesCollected--;
    }

    public void Collectdrink()
    { 
        drinksCollected++;  
    }

    public void Usedrink()
    {
        drinksCollected--;
    }

    public void Collectbread()
    {
        breadsCollected++;
    }

    public void Usebread()
    {
        breadsCollected--;
    }

    public void Collectheart()
    {
        heartsCollected++;
    }


    public IEnumerator SpeedUp()
    {
        Instantiate(Speedeffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(10f);
        GetComponent<PlayerController>().playerSpeed = 20f;
    }

    public void LifeUp()
    {
        Instantiate(Lifeeffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }

    public void MagicUp()
    {
        Instantiate(Magiceffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }

    public void EnergyUp()
    {
        Instantiate(Energyeffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }

}
