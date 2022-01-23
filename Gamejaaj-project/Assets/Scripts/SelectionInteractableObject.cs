using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionInteractableObject : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerToSelectable;    
    [SerializeField] private Transform objects;
    [SerializeField] private Transform exitObject;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private float distanceToSelection;
    private PlayerState playerState;

    [HideInInspector] public GameObject selectedObject;
    private RaycastHit hit;

    void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }
    private void Update()
    {
        Selection();
    }
    
    void Selection()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanceToSelection, layerToSelectable))
        {
            selectedObject = hit.transform.gameObject;
        }
        else
        {
            selectedObject = null;
        }
    }
}
