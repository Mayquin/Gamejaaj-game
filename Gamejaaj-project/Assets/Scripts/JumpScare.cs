using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public JumpScareScriptable jumpScare;


    public void JumpScareActivate()
    {
        Instance();
        jumpScare.jumpCam.SetActive(true);
        jumpScare.scream.Play();
        jumpScare.flashImg.SetActive(true);
        GameManager.instance.dying = true;
        transform.position = jumpScare.spawnMonster.position;
        StartCoroutine(EndJump());
    }
    public void Instance()
    {
        Instantiate(jumpScare.jumpCam);
        Instantiate(jumpScare.flashImg);
       
    }
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(jumpScare.endJump);
        jumpScare.jumpCam.SetActive(false);
        jumpScare.flashImg.SetActive(false);
        GameManager.instance.dying = false;
    }

    #region Negocios

    //[SerializeField] private AudioSource _scream;
    //[SerializeField] private GameObject _thePlayer;
    //[SerializeField] private GameObject _jumpCam;
    //[SerializeField] private GameObject _flashImg;
    //[SerializeField] private float _endJump = 2.0f;
    //[SerializeField] private Transform _spawnMonster;
    //void Initialize()
    //{
    //    _scream = jumpScare.scream;
    //    _jumpCam = jumpScare.jumpCam;
    //    _flashImg = jumpScare.flashImg;
    //    _endJump = jumpScare.endJump;
    //    _spawnMonster = jumpScare.spawnMonster;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    _jumpCam.SetActive(true);
    //    _scream.Play();
    //    _flashImg.SetActive(true);
    //    GameManager.instance.dying = true;
    //    transform.position = _spawnMonster.position;
    //    StartCoroutine(EndJump());
    //}

    //IEnumerator EndJump()
    //{
    //    yield return new WaitForSeconds(_endJump);
    //    _jumpCam.SetActive(false);
    //    _flashImg.SetActive(false);
    //    GameManager.instance.dying = false;
    //}
    #endregion
}
