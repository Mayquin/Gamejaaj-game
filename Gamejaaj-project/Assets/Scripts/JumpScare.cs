using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : Interactable
{
    public JumpScareScriptable jumpScare;
    [SerializeField] protected Transform player;
    [SerializeField] protected float distanceToPlayer = 3f;
    [SerializeField] protected List<JumpScare> jumpscare;
    [SerializeField] protected int jumpIndex;
    [SerializeField] protected float contTime = 5f;
    bool scare = false;
    bool interact = false;
    float restTime;
   
    private void Update()
    {
        if(playerState.myLifeState != LifeStates.Hided)
        RestTimeJumpScare();
    }

    
    public override void Interact()
    {
        interact = true;
        if(interact)
        Scare();
    }
    public void RestTimeJumpScare()
    {
        interact = false;
        if(Time.time > restTime)
        {
            restTime = contTime + Time.deltaTime;
            Scare();
        }

    }

    void Scare()
    {
        if (scare) return;
        jumpIndex = Random.Range(0, jumpscare.Count);

        if (Vector3.Distance(transform.position, player.position) < distanceToPlayer)
        {
            scare = true;
            jumpscare[jumpIndex].JumpScareActivate();
        }
    }

    public void JumpScareActivate()
    {
        Instance();
        jumpScare.jumpCam.SetActive(true);
        jumpScare.scream.Play();
        GameManager.instance.dying = true;
        StartCoroutine(EndJump());
    }
    public void Instance()
    {
        Instantiate(jumpScare.jumpCam); 
    }
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(jumpScare.endJump);
        jumpScare.jumpCam.SetActive(false);
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
