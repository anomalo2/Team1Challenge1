using UnityEngine;

public class OnSwitchCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SceneDirectorCS syncDirector;
    [SerializeField] private GameObject switchObject;

    public bool on_flg = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { turnOn(); }

    void Update() { }

    void turnOn()
    {
        if (on_flg == false) 
        {
            syncDirector.powerNotification();
            on_flg = true;
        }
    }

}