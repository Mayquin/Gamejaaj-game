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
    void JumpTriggerActivate()
    {
        jumpCam.SetActive(true);
        scream.Play();
        flashImg.SetActive(true);
        GameManager.instance.dying = true;
        transform.position = spawnMonster.position;
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(endJump);
        jumpCam.SetActive(false);
        flashImg.SetActive(false);
        GameManager.instance.dying = false;
    }
}
