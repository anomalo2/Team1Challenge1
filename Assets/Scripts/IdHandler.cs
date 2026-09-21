using UnityEngine;

public class IdHandler : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    [SerializeField] private GameObject[] idModel; 
    
    void Start() { reset(); }

    public void displayModel(int id) { idModel[id].SetActive(true); }

    public void reset()
    {
        foreach (GameObject ID in idModel)
        {
            ID.SetActive(false);
        }
    }
}
