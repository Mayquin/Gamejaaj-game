using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jump Scare", menuName = "JumpScare")]
public class JumpScareScriptable : ScriptableObject
{
    public AudioSource scream;
    public GameObject jumpCam;
    public float endJump = 2.0f;
    
}
