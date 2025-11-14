using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public int dinheiro = 500;
    public int energia = 100;
    public int agua = 100;
    public int sustentabilidade = 50;

    void Awake()
    {
        instance = this;
    }

    public bool TemRecursos(int din, int ene, int ag, int sust)
    {
        return dinheiro >= din && energia >= ene && agua >= ag && sustentabilidade >= sust;
    }

    public void GastaRecursos(int din, int ene, int ag, int sust)
    {
        dinheiro -= din;
        energia -= ene;
        agua -= ag;
        sustentabilidade -= sust;
    }
}
