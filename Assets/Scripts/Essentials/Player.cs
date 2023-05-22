using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxhealth = 7;
    [SerializeField] private GameObject _deathEffect, _hitEffect;
    private float _currenthealth;

    [SerializeField] private float _maxmagic = 10;
    private float _currentmagic;

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

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpeed = originalSpeed;
        _currenthealth = _maxhealth;

        _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
    }

    // Update is called once per frame
    public void TakingHit()
    {
        _currenthealth -= Random.Range(0.5f, 1.5f);

        if (_currenthealth <= 0)
        {
           Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
           Destroy(gameObject);
           gameOverScreen.SetActive(true);
        }

        else
        {
            _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
           Instantiate(_hitEffect, transform.position, Quaternion.identity);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cakecollectable")
        {
            print("I got magic");
            MagicUp.SetActive(true);
        }

        if (other.gameObject.name == "Drinkcollectable")
        {
            print("I got speed");          
        }

        if (other.gameObject.name == "breadcollectable")
        {
            print("I got health");     
        }

        if (other.gameObject.name == "heartcollectable")
        {
            print("I got life");  
        }
    }

    public void MagicUp()
    {
        _magicbar.UpdateMagicbar(-_maxmagic, _currentmagic);
    }

    public void HealthUp()
    {     
        _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);     
    }

    public void SpeedUp()
    {
        originalSpeed = maxSpeed;
    }

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
}
