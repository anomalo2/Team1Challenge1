using UnityEngine;

public class VerdictDisplay : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    [SerializeField] private GameObject holdSign; 
    [SerializeField] private GameObject acceptSign; 
    [SerializeField] private GameObject denySign; 

    //void Start() { reset(); }

    public void displayHold()
    {
        holdSign.SetActive(true);
    }

    public void displayAccept()
    {
        acceptSign.SetActive(true);
        holdSign.SetActive(false);
    }

    public void displayDeny()
    {
        denySign.SetActive(true);
        holdSign.SetActive(false);
    }

    public void reset()
    {
        holdSign.SetActive(true);
        acceptSign.SetActive(false);
        denySign.SetActive(false);
    }
}

