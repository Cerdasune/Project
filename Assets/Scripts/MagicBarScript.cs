using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBarScript : MonoBehaviour
{
    [SerializeField] private Image _Magicbarsprite;
    [SerializeField] private float _IncreaseSpeed = 2;

    public GameObject Cakemagic;

    private float _target = 1;
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;

    }

    public void UpdateMagicbar(float maxAmount, float currentAmount)
    {
        _target = currentAmount / maxAmount;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
        _Magicbarsprite.fillAmount = Mathf.MoveTowards(_Magicbarsprite.fillAmount, _target, _IncreaseSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cakecollectable")

            for (int i = 0; i < _Magicbarsprite.fillAmount; i++)
            {
                _Magicbarsprite.fillAmount = Mathf.MoveTowards(_Magicbarsprite.fillAmount, _target, _IncreaseSpeed * Time.deltaTime);

            }
    }
}
