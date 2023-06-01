using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBarScript : MonoBehaviour
{
    [SerializeField] private Image _Magicbarsprite;
    [SerializeField] private float _IncreaseSpeed = 4;

    public GameObject Cakemagic;
    public GameObject Beam;
    public Transform gun;

    private float _target = 0;
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;

    }

    public void UpdateMagicbar(float magic)
    {
        if(_target <= 1)
        {
            print("Fill Magic");
            _target = _target + magic;
        }

        if(_target == 1)
        {
            //gameObject.GetComponent<PlayerController>().Shootlazer();
           Instantiate(Beam, gun.position, gun.rotation);
            _target = 0;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
        _Magicbarsprite.fillAmount = Mathf.MoveTowards(_Magicbarsprite.fillAmount, _target, _IncreaseSpeed * Time.deltaTime);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cakecollectable")

            for (int i = 0; i < _Magicbarsprite.fillAmount; i++)
            {
                _Magicbarsprite.fillAmount = Mathf.MoveTowards(_Magicbarsprite.fillAmount, _target, _IncreaseSpeed * Time.deltaTime);

            }
    }
    */
}
