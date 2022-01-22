using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
   [SerializeField] private bool isOn = false;
   [SerializeField] private GameObject lightSource;
   [SerializeField] private AudioSource clickSound;
   [SerializeField] private KeyCode lanternButton;
   [SerializeField] private bool fail = false;

    void Update()
    {
        TurnFlashLight();
    }


    public void TurnFlashLight()
    {
        if (Input.GetKeyDown(lanternButton))
        {
            if(!isOn && !fail)
            {
                fail = true;
                lightSource.SetActive(true);
                //clickSound.Play();
                isOn = true;
                StartCoroutine(Fail());
            }
            else
            {
                fail = true;
                lightSource.SetActive(false);
                //clickSound.Play();
                isOn = false;
                StartCoroutine(Fail());
            }
        }

        if(Controlador.controlador.isHiden)
        {
            lightSource.SetActive(false);
        }
        else
        {
            lightSource.SetActive(true);
        }
    }

    IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.25f);
        fail = false;
    }
}
