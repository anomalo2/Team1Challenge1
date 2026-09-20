using System.Collections;
using UnityEngine;

public class AcptLeverCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SyncDirectorCS syncDirector;

    public bool select_flg = false;

    //void Start(){ }

    public void ActivateAcceptLever() 
    {        
        if( syncDirector.consolePowered == true && syncDirector.arrived == true)
        {
            if ( select_flg == false ) 
            { 
                select_flg = true; 
                syncDirector.decideNotification();
            }
        }
    }

    public void reset() { select_flg = false; }
}
