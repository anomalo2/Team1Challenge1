using UnityEngine;

public class AcptLightCS : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    [SerializeField] public Material onMaterial; 
    [SerializeField] public Material offMaterial; 

    private MeshRenderer meshRenderer;

    void Start() { meshRenderer = GetComponent<MeshRenderer>(); }

    //void Update(){ }

    public void TurnON()
    {
        meshRenderer.material = onMaterial;
    }

    public void TurnOFF()
    {
        meshRenderer.material = offMaterial;
    }
}
