using UnityEngine;

public class FarmState : PinnapleBaseState
{
    
    Vector3 startPinnaplePosition = new Vector3(0, 651, -360);
    float velRotacao = 20;
    GameObject cameraMuda;




    public override void EnterState(PinnapleStateManager pinnaple)
    {
        cameraMuda = pinnaple.Camera;
        cameraMuda.transform.LeanMove(startPinnaplePosition, 2);
        
    }
    public override void UpdateState(PinnapleStateManager pinnaple)
    {

        cameraMuda = pinnaple.Camera;
        Vector3 look = new Vector3(0, 0, 0);
        cameraMuda.transform.LookAt(look);

         cameraMuda.transform.RotateAround(look, Vector3.up, velRotacao * Time.deltaTime);
        
        if (pinnaple.opcoes == 1)
        {
            pinnaple.switchState(pinnaple.singlePlant);

        }
    }
}
