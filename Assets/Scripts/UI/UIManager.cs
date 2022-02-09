using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Instance
    public static UIManager instace;
    private void Awake() => instace = this;
    #endregion

    [SerializeField] TextMeshProUGUI daysText;
    [SerializeField] TextMeshProUGUI daysSpeed;
    [SerializeField] GameObject dataPrefab;
    [SerializeField] Transform AnchorData;
    [SerializeField] float tempoDia;
    [SerializeField] Button inputDay;
    [SerializeField] GameObject inputField;
    [SerializeField] Slider slider;
    [SerializeField] GameObject uiHolder;

    private float timeRemaing = 0;
    bool pausa = true;



    List<DataContainer> dataContainers = new List<DataContainer>();

    bool inited = false;
    bool validation = false;

    private void Start()
    {
        daysText.text = "Days :" + 0;
        daysSpeed.text = "Speed :" + 0;


        InstantiateAndSetData("Soma Graus Dia :", PineappleController.instance.somaGrausDia.ToString());
        InstantiateAndSetData("Numero de Folhas :", PineappleController.instance.NumeroDeFolhasDia().ToString("0.00"));
        InstantiateAndSetData("Diametro Do caule :", PineappleController.instance.DiametroCaule().ToString("0.00") + "cm");
        InstantiateAndSetData("Altura :", PineappleController.instance.CalculoAltura(PineappleController.instance.somaGrausDia).ToString("0.00"));

        inited = true;
    }

    private void Update()
    {
        if (inited)
        {
            dataContainers[0].SetValue(PineappleController.instance.somaGrausDia.ToString());
            dataContainers[1].SetValue(PineappleController.instance.NumeroDeFolhasDia().ToString());
            dataContainers[2].SetValue(PineappleController.instance.DiametroCaule().ToString("0.00") + "cm");
            dataContainers[3].SetValue(PineappleController.instance.CalculoAltura(PineappleController.instance.somaGrausDia).ToString("0.00"));
        }

        SliderControl();
        SetSpeedToText();

    }

    private IEnumerator AutoSlider()
    {
        do
        {
            timeRemaing += 1;
            slider.value = timeRemaing;
          yield return new WaitForSeconds(tempoDia);

            
        } while (pausa != true && timeRemaing <= 859); 
    }


    public void SetDaysToText()
    {
        int value = (int)slider.value;
        daysText.text = "Days :" + value;
    }

    public void SetSpeedToText()
    {
        int value = (int)slider.value;
        daysSpeed.text = "Velocidade do dia : " + tempoDia;
    }

    public void AutomatizeSlider()
    {
        int value = (int)slider.value;
        daysText.text = "Days :" + value;
    }

    public void InstantiateAndSetData(string dataType, string value)
    {
        GameObject go = Instantiate(dataPrefab) as GameObject;

        go.transform.SetParent(AnchorData);
        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;

        DataContainer data = go.GetComponent<DataContainer>();
        SetUIData(data, dataType, value);

        dataContainers.Add(data);
    }

    public void InstantiateUiObj()
    {
        GameObject go = Instantiate(dataPrefab) as GameObject;

        go.transform.SetParent(AnchorData);
        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;
    }

    public void SetUIData(DataContainer data, string dataType, string value) => data.SetBothUiValues(dataType, value);

    public void ValidateString(TMP_InputField text)
    {
        validation = CheckValidString(text.text);

        if (validation)
        {
            inputDay.interactable = true;
            inputField.SetActive(false);

            int number;
            int.TryParse(text.text, out number);
            slider.value = number;
            PineappleController.instance.SetDia(number);
        }
    }

    bool CheckValidString(string s)
    {
        int number;
        if (int.TryParse(s, out number))
        {
            if (number >= 0 && number <= 800)
            {
                return true;
            }
        }

        return false;
    }


    public void SliderControl()
    {
        if (Input.GetKeyDown("w"))
        {
            uiHolder.SetActive(false);

        }
        if (Input.GetKeyDown("q"))
        {
            uiHolder.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pausa == true)
            {
                pausa = false;
                StartCoroutine(AutoSlider());
            }
           else if(pausa == false)
            {
                pausa = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            timeRemaing = 0;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            tempoDia = tempoDia + 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            tempoDia = tempoDia - 0.1f;
        }
    }
}