using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _Healthbarsprite;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _Healthbarsprite.fillAmount = currentHealth / maxHealth; 
    }
}
