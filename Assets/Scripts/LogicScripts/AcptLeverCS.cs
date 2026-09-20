using System.Collections;
using UnityEngine;

public class AcptLeverCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SceneDirectorCS syncDirector;

    public bool select_flg = false;

    void Start()
    {
        
    }

    void Update()
    {
        // Wait until console is powered (player clocks in)
        while( syncDirector.consolePowered == false ) {}

        while( syncDirector.arrived == false ) {}
    }

    void interacted()
    {
        if (select_flg == false) { select_flg = true; }
        syncDirector.decideNotification();
    }

    public void reset() { select_flg = false; }
}
