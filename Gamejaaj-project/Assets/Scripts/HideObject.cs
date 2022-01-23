using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField] private KeyCode hideButton = KeyCode.E;
    [SerializeField] private Transform player;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Transform exitObject;
    [SerializeField] private GameObject flashLight;


    public void OnTriggerStay(Collider other)
    {
        if (playerTag == other.tag && !Controlador.controlador.isHiden && Controlador.controlador.canEnter)
        {
            Hide();
        }
        else if(playerTag == other.tag && Controlador.controlador.isHiden)
        {
            UnHide();
        }
    }


    public void Hide()
    {
        if(Input.GetKeyDown(hideButton))
        {
            player.position = transform.position;
            player.rotation = transform.rotation;

            flashLight.SetActive(false);
            Controlador.controlador.isHiden = true;
            Controlador.controlador.blockInputs = true;
        }
    }

    public void UnHide()
    {
        if (Input.GetKeyDown(hideButton))
        {
            player.position = exitObject.position;
            player.rotation = exitObject.rotation;

            flashLight.SetActive(true);
            Controlador.controlador.isHiden = false;
            Controlador.controlador.blockInputs = false;
        }
    }
}
