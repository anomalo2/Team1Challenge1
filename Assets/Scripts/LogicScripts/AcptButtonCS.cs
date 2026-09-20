using System.Collections;
using UnityEngine;

public class AcptButtonCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SceneDirectorCS syncDirector;

    public bool select_flg = false;

    void Start()
    {
        //StartCoroutine(waitValidation());
    }

    void Update()
    {
        
    }

    IEnumerator waitValidation()
    {
        // Wait until console is powered (player clocks in).

        while ( !syncDirector.consolePowered ) { yield return null; }

        // Wait for driver to reach the booth.

        while ( !syncDirector.arrived ) { yield return null; }
    }


    

    void interacted()
    {
        if( syncDirector.consolePowered == true && syncDirector.arrived == true)
        {
            if (select_flg == false && syncDirector.decision == false) 
            { 
                select_flg = true; 
            }
            syncDirector.decideNotification();
        }
    }

    public void reset() { select_flg = false; }
}
