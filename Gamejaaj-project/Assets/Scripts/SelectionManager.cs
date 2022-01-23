using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Camera cam;
    [SerializeField] private string selectable = "Selectable";
    [SerializeField] private Material defaultMaterial;
    
    [SerializeField] private KeyCode hideButton = KeyCode.E;
    [SerializeField] private Transform objects;
    [SerializeField] private Transform exitObject;
    [SerializeField] private GameObject flashLight;

    private Transform _selection;

    private void Update()
    {
        Selection();
    }


    public void OnTriggerStay(Collider other)
    {
       
            
        
    }


    void Selection()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectable))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;

                GameManager.instance.canEnter = true;
            }
            else
            {
                GameManager.instance.canEnter = false;
            }
        }
    }

    public void Hide()
    {

        if (Input.GetKeyDown(hideButton))
        {
            transform.position = objects.position;
            transform.rotation = transform.rotation;

            flashLight.SetActive(false);
            GameManager.instance.isHiden = true;
            GameManager.instance.blockInputs = true;
        }

    }

    public void UnHide()
    {
        if (Input.GetKeyDown(hideButton))
        {
            transform.position = exitObject.position;
            transform.rotation = exitObject.rotation;

            flashLight.SetActive(true);
            GameManager.instance.isHiden = false;
            GameManager.instance.blockInputs = false;
        }
    }
}
