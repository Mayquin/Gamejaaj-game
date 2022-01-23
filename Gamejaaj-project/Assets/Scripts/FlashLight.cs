using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
   private bool isOn = false;
   private bool fail = false;
   [SerializeField] private KeyCode lanternButton;
   [SerializeField] private GameObject lightSource;
   [SerializeField] private AudioSource clickSound;

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
                fail = true; // what would this variable be for ?
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

        
    }

    IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.25f);
        fail = false;
    }
}
