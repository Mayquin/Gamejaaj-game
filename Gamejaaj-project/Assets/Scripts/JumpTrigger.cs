using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource scream;
    [SerializeField] private GameObject thePlayer;
    [SerializeField] private GameObject jumpCam;
    [SerializeField] private GameObject flashImg;
    [SerializeField] private float endJump = 2.0f;
    [SerializeField] private Transform spawnMonster;


    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        jumpCam.SetActive(true);
        scream.Play();
        //thePlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        flashImg.SetActive(true);
        Controlador.controlador.dying = true;
        transform.position = spawnMonster.position;
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(endJump);
       // thePlayer.GetComponent<Rigidbody>().velocity = Vector3.one;
        jumpCam.SetActive(false);
        flashImg.SetActive(false);
        Controlador.controlador.dying = false;
    }
}
