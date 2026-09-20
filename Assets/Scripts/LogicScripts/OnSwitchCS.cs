using UnityEngine;

public class OnSwitchCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SyncDirectorCS syncDirector;

    public bool on_flg = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start() { turnOn(); }

    //void Update() { }

    public void ActivateSwitch()
    {
        if (on_flg == false) 
        {
            on_flg = true;
            syncDirector.powerNotification();
        }
    }

}