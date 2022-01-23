using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isHiden = false;
    public bool blockInputs = false;
    public Transform player;
    public bool dying = false;
    public bool canEnter = false;
    [Header("Events we likely call")]
    public Events events;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        events.HideCursor();   
    }
}
