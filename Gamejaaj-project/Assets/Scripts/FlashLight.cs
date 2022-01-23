using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
   [SerializeField] private KeyCode lanternButton;
   [SerializeField] private GameObject lightSource;
   [SerializeField] private AudioSource clickSound;
   private bool isOn = false;
   private bool lockedFlashLight = true;
   private bool inAnimation = false;
   private Animator animator;

   void Awake()
   {
       animator = GetComponentInChildren<Animator>();
   }

   void Update()
    {
        HandleFlashLight();
    }

    public IEnumerator StartAnimGetFlashLight()
    {
        inAnimation = true;
        animator.SetTrigger("GetFlashLight");
        // animation lenght hardcoded
        yield return new WaitForSeconds(1f);
        inAnimation = false;
        lockedFlashLight = false;
        lightSource.gameObject.GetComponent<Light>().intensity = 25f;
    }

    public void HandleFlashLight()
    {
        if (inAnimation) return;

        if (lockedFlashLight) return;
        
        if (Input.GetKeyDown(lanternButton))
        {
            TurnFlashLight();
        }
    }

    public void TurnFlashLight()
    {
        isOn = !lightSource.activeSelf;
        lightSource.SetActive(!lightSource.activeSelf);
    }
}
