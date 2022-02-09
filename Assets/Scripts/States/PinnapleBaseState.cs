using UnityEngine;

public abstract class PinnapleBaseState 
{
    public abstract void EnterState(PinnapleStateManager pinnaple);

    public  abstract void UpdateState(PinnapleStateManager pinnaple);
}
