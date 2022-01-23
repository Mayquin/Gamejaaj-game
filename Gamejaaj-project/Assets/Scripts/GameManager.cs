using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isHiden = false;
    public bool blockInputs = false;
    public GameObject player;
    public bool dying = false;
    public bool canEnter = false;
    [Header("Events we likely call")]
    public Event events;
    
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
        
    }
}
