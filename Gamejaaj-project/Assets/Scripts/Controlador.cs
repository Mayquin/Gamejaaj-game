using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public static Controlador controlador;
    public bool isHiden = false;
    public bool blockInputs = false;

    void Start()
    {
        controlador = this;
    }
}
