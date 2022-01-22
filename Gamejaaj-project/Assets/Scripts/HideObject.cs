using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField] private KeyCode hideButton = KeyCode.E;
    [SerializeField] private Transform player;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Transform exitObject;
    


    public void OnTriggerStay(Collider other)
    {
        if (playerTag == other.tag && !Controlador.controlador.isHiden)
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
            Debug.Log("Hide");
            player.position = transform.position;
            player.rotation = transform.rotation;

            Controlador.controlador.isHiden = true;
            Controlador.controlador.blockInputs = true;
        }
    }

    public void UnHide()
    {
        if (Input.GetKeyDown(hideButton))
        {
            Debug.Log("UnHide");
            player.position = exitObject.position;
            player.rotation = exitObject.rotation;

            Controlador.controlador.isHiden = false;
            Controlador.controlador.blockInputs = false;
        }
    }
}
