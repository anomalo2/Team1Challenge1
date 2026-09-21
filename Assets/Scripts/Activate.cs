using UnityEngine;
using TMPro;

public class Activate : MonoBehaviour
{
    public GameObject Open;
    public GameObject Close;
    public void ActivateAcceptLever() 
    {
        //Debug.Log("Accept Lever");
    }

    public void ActivateSwitch()
    {
        //Debug.Log("Switch");
        Close.SetActive(false);
        Open.SetActive(true);

    }

    public void ActivateDenyLever()
    {
        //Debug.Log("Deny Lever");
    }
}
