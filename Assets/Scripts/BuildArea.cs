using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public Transform buildPoint;
    public bool ocupada = false;

    public void OcupaArea()
    {
        ocupada = true;
    }
}
