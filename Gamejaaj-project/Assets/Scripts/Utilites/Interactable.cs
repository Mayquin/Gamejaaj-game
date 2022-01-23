using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected float distanceToInteract;
    [SerializeField] protected KeyCode inputToInteract;
    [SerializeField] protected Material highlightMaterial;
    [SerializeField] protected Material defaultMaterial;
    protected Renderer rendererProperties;
    
    // player scripts you might need in some interactions
    protected SelectionInteractableObject playerSelection;
    protected PlayerState playerState;

    void Awake()
    {
        rendererProperties = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        if (GameManager.instance.player)
        {
            if (Vector3.Distance(transform.position, GameManager.instance.player.position) < distanceToInteract)
            {
                if (!playerSelection)
                {
                    playerSelection = GameManager.instance.player.GetComponent<SelectionInteractableObject>();
                    playerState = GameManager.instance.player.GetComponent<PlayerState>();
                    SetStateOfPlayer();
                }
                else
                {
                    ShowItIsSelected();
                }
                if (Input.GetKeyDown(inputToInteract) && playerSelection.selectedObject == gameObject)
                {
                    Interact();
                }                
            }
            else
            {
                rendererProperties.material = defaultMaterial;
                playerSelection = null;
                playerState = null;
            }
        }
    }

    public virtual void SetStateOfPlayer()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log("Não está dando override");
    }

    public virtual void ShowItIsSelected()
    {
        if (playerSelection)
        {
            if (playerSelection.selectedObject == gameObject)
            {
                rendererProperties.material = highlightMaterial;
            }
            else
            {
                rendererProperties.material = defaultMaterial;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceToInteract);
    }
}
