using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jump Scare", menuName = "JumpScare")]
public class JumpScareScriptable : ScriptableObject
{
    public GameObject jumpScareMonster;
    [SerializeField] private AudioSource scream;
    [SerializeField] private GameObject thePlayer;
    [SerializeField] private GameObject jumpCam;
    [SerializeField] private GameObject flashImg;
    [SerializeField] private float endJump = 2.0f;
    [SerializeField] private Transform spawnMonster;

}
