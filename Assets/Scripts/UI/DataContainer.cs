using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataContainer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dataTypeText;
    [SerializeField] TextMeshProUGUI ValueText;

    public void SetBothUiValues(string dataType, string value) 
    {
        dataTypeText.text = dataType;
        ValueText.text = value;
    }

    public void SetValue(string value)
    {
        ValueText.text = value;
    }
}
