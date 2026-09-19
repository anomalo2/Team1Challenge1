using UnityEngine;

public class DenyButtonCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SceneDirectorCS syncDirector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while( syncDirector.consolePowered == false ) {}
    }
}
