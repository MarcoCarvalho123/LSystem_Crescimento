using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FolhaBlendShape : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer meshRenderer;

    public float vertical;
    public float horizontal;
    public Vector3 baseDoCaule = new Vector3 (100,0,100);
    [SerializeField] int geracao;
    [SerializeField] float posicao;
    [SerializeField] BlendNames blendNames;


    public void InitFolha(int NewGen, float CirclePos, Vector3 setBase)
    {
        geracao = NewGen;
        posicao = CirclePos + UnityEngine.Random.Range(-3f, 6f);
        baseDoCaule = setBase;
        posicionarFolha();
        LookToCoule();

        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        blendNames = ReturnBlendByGen(geracao);
        EffectBlendShape(blendNames, 100);
    }

    public void posicionarFolha()
    {
        float diametroCaule = PineappleController.instance.DiametroCaule() + 1; // offset
        diametroCaule = diametroCaule + 1f;
        PosicaoNoDiametro();
        Vector3 spawnDir = new Vector3(horizontal, 0, vertical);
        Vector3 spawnPos = baseDoCaule + spawnDir * -diametroCaule + (-Vector3.forward * 2f) + (-Vector3.right * 0.5f);
        spawnPos += Vector3.up * geracao * PineappleController.instance.DiferencaDeAlturaPorGeracao;
        transform.position = transform.forward + spawnPos;
        transform.position -= -transform.forward;
    }

    public void PosicaoNoDiametro()
    {
        float radians = 2 * Mathf.PI / PineappleController.instance.NumeroDeFolhasPorGeracao * posicao;
        vertical = Mathf.Sin(radians); //* UnityEngine.Random.Range(0f, f);
        horizontal = Mathf.Cos(radians);// * UnityEngine.Random.Range(0f, 300f);
        // Debug.Log(vertical + "-" + horizontal);
    }

    public void GeracaoDaFolha(GameObject folha, float DiferencadeAltura)
    {
        folha.transform.position += Vector3.up * DiferencadeAltura * PineappleController.instance.CalculoAltura();
    }

    public void EffectBlendShape(BlendNames names, int weight)
    {
        meshRenderer.SetBlendShapeWeight((int)names, weight);
    }

    public void SetBlendByGeneration(int gen)
    {

    }

    BlendNames ReturnBlendByGen(int gen)
    {
        BlendNames retVal = BlendNames.FlolhaFromaB;

        if (gen == 9)
        {

        }
        else if (gen < 5)
        {
            gen += 5;
            retVal = (BlendNames)(Enum.GetValues(retVal.GetType())).GetValue(gen);
        }
        else
        {
            retVal = (BlendNames)(Enum.GetValues(retVal.GetType())).GetValue(gen);
        }

        return retVal;
    }

    public void TurnOFFMeshRenderer()
    {
        meshRenderer.enabled = false;
    }

    public void TurnOnMeshRenderer()
    {

        meshRenderer.enabled = true;
    }

    public void LookToCoule()
    {
        Vector3 dir = baseDoCaule;
        dir.y = transform.position.y;
        transform.LookAt(dir);
    }
}

public enum BlendNames
{
    FlolhaFromaB,
    FlolhaFromaC,
    FlolhaFromaD,
    FlolhaFromaE,
    FlolhaFromaF,
    FlolhaFromaABending,
    FlolhaFromaBBending,
    FlolhaFromaCBending,
    FlolhaFromaDBending,
    FlolhaFromaEBending,
    FlolhaFromaFBending,
}