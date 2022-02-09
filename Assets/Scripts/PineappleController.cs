using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleController : MonoBehaviour
{
    #region instance
    public static PineappleController instance;
    private void Awake() => instance = this;
    #endregion

    public float somaGrausDia;
    public float temperaturaMedia;
    public int dia;
    public int NumeroDeFolhasPorGeracao = 3;
    public float DiferencaDeAlturaPorGeracao;

    public void addDay()
    {
        dia++;
        updateSomaGrausDias();
    }
    public void removeDay()
    {
        dia--;
        updateSomaGrausDias();
    }

    public void SetDia(int newDia)
    {
        dia = newDia;
        updateSomaGrausDias();
    }

    public void updateSomaGrausDias()
    {
        somaGrausDia = dia * GrauDia();
    }

    public float GrauDia()
    {
        return temperaturaMedia - 10f;
    }

    public float GrauDia(int dia)
    {
        return GrauDia() * dia;
    }

    public float CalculoAltura(float GrausDias)
    {
        float altura = 132.4215f / (1 + (Mathf.Exp(-(GrausDias - 3608.9383f) / 2969.8105f)));

        return altura;
    }

    public float CalculoAltura()
    {
        float altura = 132.4215f / (1 + (Mathf.Exp(-(somaGrausDia - 3608.9383f) / 2969.8105f)));
        return altura;
    }

    public float DiametroCaule()
    {
    
        float aux = -((somaGrausDia - 668.7439f) / 4514.7463f);
        float FormulaDiametro = 5.7989f / (1 + Mathf.Exp(aux));
        return FormulaDiametro;
    }

    public float NumeroDeFolhasDia(float GrausDias)
    {
        float aux = -0.5f * (Mathf.Pow((GrausDias - 2418.0462f) / 3514.5939f, 2));
        float numeroDeFolha = 33.2175f - (17.1206f * Mathf.Exp(aux));
        return Mathf.RoundToInt(numeroDeFolha);
    }

    public float NumeroDeFolhasDia()
    {
        float aux = -0.5f * (Mathf.Pow((somaGrausDia - 2418.0462f) / 3514.5939f, 2));
        float numeroDeFolha = 33.2175f - (17.1206f * Mathf.Exp(aux));
        return Mathf.RoundToInt(numeroDeFolha);
    }
}