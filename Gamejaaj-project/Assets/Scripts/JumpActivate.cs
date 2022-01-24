using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpActivate : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float distanceToPlayer = 3f;
    [SerializeField] protected JumpScare[] jumpScare;
    [SerializeField] protected int jumpIndex;
    [SerializeField] protected PlayerState playerStates;
    bool scare = false;

    void Update()
    {
         Scare();
    }
    void Scare()
    {
        if (scare) return;
        jumpIndex = Random.Range(0, jumpScare.Length);

        if (Vector3.Distance(transform.position, player.position) < distanceToPlayer)
        {
            jumpScare[jumpIndex].JumpScareActivate();

            scare = true;
        }
    }
}
