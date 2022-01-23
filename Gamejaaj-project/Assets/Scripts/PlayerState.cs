using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LifeStates
{
    Default,
    Scared,
    CanHide,
    Hided,
    Dead,
    StopInput
}
public class PlayerState : MonoBehaviour
{
    public LifeStates myLifeState;
    
    void Start()
    {
        myLifeState = LifeStates.Default;
    }

    void Update()
    {
        
    }

    public void SetState(LifeStates state)
    {
        myLifeState = state;
    }
}
