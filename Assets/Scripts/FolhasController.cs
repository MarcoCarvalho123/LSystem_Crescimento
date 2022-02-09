using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolhasController : MonoBehaviour
{
    public GeneralController generalController;
    [SerializeField] GameObject leafPrefab;
    public List<GameObject> folhas;
    public Transform parent;
    public Vector2 DeviationRange;
    Vector2 GeracaoPos;
    public int AlturaMaximaDeCrescimento;


    private void Start()
    {
        CriarTodasAsFolhas();
    }

    void CriarTodasAsFolhas()
    {
        int NumeroDeFolhasTotal = (int)PineappleController.instance.NumeroDeFolhasDia(PineappleController.instance.GrauDia(859));
        for (int i = 0; i < NumeroDeFolhasTotal; i++)
        {
            CreateLeaf();
        }
        UpdateNumberOFleaves();
    }

    public void UpdateNumberOFleaves()
    {
        for (int i = 0; i < folhas.Count; i++)
        {
            if(i< PineappleController.instance.NumeroDeFolhasDia())
            {
                folhas[i].GetComponent<FolhaBlendShape>().TurnOnMeshRenderer();
            }
            else
            {
                folhas[i].GetComponent<FolhaBlendShape>().TurnOFFMeshRenderer();
            }
        }

    }



    [ContextMenu("New Leaf")]
    public void CreateLeaf()
    {
        GameObject NovaFolha = Instantiate(leafPrefab, Vector3.zero, Quaternion.identity, parent) as GameObject;
        FolhaBlendShape folha = NovaFolha.GetComponent<FolhaBlendShape>();
        folha.InitFolha((int)GeracaoPos.y, (int)GeracaoPos.x,parent.position);
        folhas.Add(NovaFolha);
        GeracaoPos.x++;
        if (GeracaoPos.x >= PineappleController.instance.NumeroDeFolhasPorGeracao)
        {
            GeracaoPos.x = 0;
            GeracaoPos.y++;
        }
    }
}