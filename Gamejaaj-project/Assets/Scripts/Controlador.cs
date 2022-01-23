using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public static Controlador controlador;
    public bool isHiden = false;
    public bool blockInputs = false;
    public GameObject player;
    public bool dying = false;
    public bool canEnter = false;

    void Start()
    {
        
        controlador = this;
    }
}
