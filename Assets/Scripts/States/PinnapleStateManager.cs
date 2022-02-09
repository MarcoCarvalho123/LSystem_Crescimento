using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinnapleStateManager : MonoBehaviour
{

    public PinnapleBaseState currentState;
    public FarmState farmState = new FarmState();
    public SingleRowState singleRow = new SingleRowState();
    public SinglePlantState singlePlant = new SinglePlantState();

    public GameObject Camera;
    public GameObject SinglePlant;
    public GameObject SingleRow;
    public GameObject DoubleRow;

    public int opcoes = 1;
   

    // Start is called before the first frame update
    void Start()
    {
       currentState = singlePlant;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            opcoes = opcoes + 1;
        }

        if (opcoes == 1)
        {
            SinglePlant.SetActive(true);
            SingleRow.SetActive(false);
            DoubleRow.SetActive(false);
        }
        else if (opcoes == 2)
        {
            SinglePlant.SetActive(false);
            SingleRow.SetActive(true);
            DoubleRow.SetActive(false);
        }
        else if (opcoes == 3)
        {
            SinglePlant.SetActive(false);
            SingleRow.SetActive(false);
            DoubleRow.SetActive(true);
        }
        else if (opcoes == 4)
        {
            opcoes = 1;
        }




    }

   public void switchState(PinnapleBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }



}
