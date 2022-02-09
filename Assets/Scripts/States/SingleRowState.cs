using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRowState : PinnapleBaseState
{
    float velRotacao = 20;
    Vector3 cameraInicia = new Vector3(0, 447, -490);
    GameObject cameraMuda;


    public override void EnterState(PinnapleStateManager pinnaple)
    {
        cameraMuda = pinnaple.Camera;
        cameraMuda.transform.LeanMove(cameraInicia, 2);
    }
    public override void UpdateState(PinnapleStateManager pinnaple)
    {
        cameraMuda = pinnaple.Camera;
        Vector3 look = new Vector3(0, 0, 0);


        cameraMuda.transform.RotateAround(look, Vector3.up, velRotacao * Time.deltaTime);
        cameraMuda.transform.LookAt(look);

        if (pinnaple.opcoes == 3)
        {
            pinnaple.switchState(pinnaple.farmState);
        }

    }

}
