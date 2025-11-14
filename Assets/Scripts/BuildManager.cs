using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject prefabUsinaSolar;
    public GameObject prefabHortaUrbana;
    public GameObject prefabCentroReciclagem;

    [Header("Ghost Previews")]
    public GameObject ghostUsinaSolar;
    public GameObject ghostHortaUrbana;
    public GameObject ghostCentroReciclagem;

    [Header("UI")]
    public GameObject painelConstrucao;

    private BuildArea areaAtual;
    private GameObject previewAtual;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && previewAtual == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out BuildArea area))
                {
                    if (area.ocupada == false)
                    {
                        areaAtual = area;
                        painelConstrucao.SetActive(true);
                    }
                }
            }
        }
    }

    #region SISTEMA DE CONSTUCAO
    public void EscolherUsinaSolar()
    {
        CriarPreview(ghostUsinaSolar);
    }

    public void EscolherHortaUrbana()
    {
        CriarPreview(ghostHortaUrbana);
    }

    public void EscolherCentroReciclagem()
    {
        CriarPreview(ghostCentroReciclagem);
    }

    void CriarPreview(GameObject ghost)
    {
        painelConstrucao.SetActive(false);
        previewAtual = Instantiate(ghost, areaAtual.buildPoint.position, areaAtual.buildPoint.rotation);
    }

    void Construir(GameObject prefab, int din, int ene, int ag, int sust)
    {
        if (!ResourceManager.instance.TemRecursos(din, ene, ag, sust))
        {
            Debug.Log("Recursos insuficientes!");
            return;
        }

        Destroy(previewAtual);

        Instantiate(prefab, areaAtual.buildPoint.position, areaAtual.buildPoint.rotation);

        ResourceManager.instance.GastaRecursos(din, ene, ag, sust);

        areaAtual.OcupaArea();
        previewAtual = null;
    }
    #endregion

    #region BOTOES DE CONFIRMAÇÃO
    public void ConfirmarUsinaSolar()
    {
        Construir(prefabUsinaSolar, 100, 30, 10, -5);
    }

    public void ConfirmarHortaUrbana()
    {
        Construir(prefabHortaUrbana, 50, 5, 10, +10);
    }

    public void ConfirmarCentroReciclagem()
    {
        Construir(prefabCentroReciclagem, 70, 10, 5, +20);
    }

    public void CancelarConstrucao()
    {
        Destroy(previewAtual);
        previewAtual = null;
    }
    #endregion
}
