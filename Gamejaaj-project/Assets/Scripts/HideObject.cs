using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : Interactable
{
    [SerializeField] private Camera myCamera;
    
    public override void SetStateOfPlayer()
    {
        playerState.myLifeState = LifeStates.CanHide;
    }
    
    public override void Interact()
    {
        if (playerState.myLifeState == LifeStates.CanHide)
        {
            Hide();
            playerState.SetState(LifeStates.Hided);
        }
        else if (playerState.myLifeState == LifeStates.Hided)
        {
            UnHide();
            playerState.SetState(LifeStates.Default);
        }
    }
    
    public void Hide()
    {
        myCamera.gameObject.SetActive(true);
        GameManager.instance.player.gameObject.SetActive(false);
        GameManager.instance.isHiden = true;
        GameManager.instance.blockInputs = true;
    }

    public void UnHide()
    {         
        GameManager.instance.player.gameObject.SetActive(true);
        myCamera.gameObject.SetActive(false);
        GameManager.instance.isHiden = false;
        GameManager.instance.blockInputs = false;
    }
}
