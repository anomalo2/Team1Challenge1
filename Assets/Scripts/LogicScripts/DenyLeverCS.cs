using UnityEngine;

public class DenyLeverCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SyncDirectorCS syncDirector;

    public bool select_flg = false;

    //void Start(){ }

    public void ActivateDenyLever() 
    {
        if( syncDirector.consolePowered == true && syncDirector.arrived == true)
        {
            if (select_flg == false && syncDirector.decision == false) 
            { 
                select_flg = true; 
                syncDirector.decideNotification();
            }
        }
    }

    public void reset() { select_flg = false; }
}
