using UnityEngine;

public class signHandler : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    [SerializeField] private GameObject closedSign;
    [SerializeField] private GameObject openSign;

    public void TurnON() 
    { 
        closedSign.SetActive(false); 
        openSign.SetActive(true); 
    }

    public void TurnOFF() 
    { 
        openSign.SetActive(false); 
        closedSign.SetActive(true); 
    }
}
