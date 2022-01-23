using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItemToPlayer : Interactable
{
    public override void Interact()
    {
        FlashLight _flashLight = playerSelection.transform.GetComponentInChildren<FlashLight>();

        if (_flashLight)
        {
            StartCoroutine(_flashLight.StartAnimGetFlashLight());
        }

        ResetToDefault();
        this.enabled = false;
    }

    public void ResetToDefault()
    {
        rendererProperties.material = defaultMaterial;
    }
}
