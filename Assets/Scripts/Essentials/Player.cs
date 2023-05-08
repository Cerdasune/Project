using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxhealth = 7;
    [SerializeField] private GameObject _deathEffect, _hitEffect;
    private float _currenthealth;

    [SerializeField] private HealthBar _healthbar;

    // Start is called before the first frame update
    void Start()
    {
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

        }

        else
        {
            _healthbar.UpdateHealthBar(_maxhealth, _currenthealth);
           Instantiate(_hitEffect, transform.position, Quaternion.identity);

        }
    }
        
}
