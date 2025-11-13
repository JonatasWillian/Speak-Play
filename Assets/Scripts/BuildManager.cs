using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [Header("Prefabs de Construções")]
    public GameObject prefabUsinaSolar;
    public GameObject prefabHortaUrbana;
    //public GameObject prefabCentroReciclagem;

    [Header("UI")]
    public GameObject painelConstrucao;

    private Vector3 localConstrucao;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("BuildArea"))
                {
                    localConstrucao = hit.collider.transform.position;
                    painelConstrucao.SetActive(true);
                }
            }
        }
    }

    public void ConstruirUsinaSolar()
    {
        Instantiate(prefabUsinaSolar, localConstrucao, Quaternion.identity);
        painelConstrucao.SetActive(false);
    }

    public void ConstruirHortaUrbana()
    {
        Instantiate(prefabHortaUrbana, localConstrucao, Quaternion.identity);
        painelConstrucao.SetActive(false);
    }

    //public void ConstruirCentroReciclagem()
    //{
    //    Instantiate(prefabCentroReciclagem, localConstrucao, Quaternion.identity);
    //    painelConstrucao.SetActive(false);
    //}
}
