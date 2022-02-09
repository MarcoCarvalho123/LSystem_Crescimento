using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SplineMesh;

public class GeneralController : MonoBehaviour
{


    public void AtualizarDia(Slider dia)
    {
        PineappleController.instance.SetDia(((int)dia.value));
    }

}