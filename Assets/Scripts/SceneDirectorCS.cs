using UnityEngine;

public class SceneDirectorCS : MonoBehaviour
{
    // Create a reference slot for your scripts

    [SerializeField] public GameObject CarObject;
    [SerializeField] private GameObject PointA;
    [SerializeField] private GameObject PointB;
    [SerializeField] private GameObject PointC;

    [SerializeField] private OnSwitchCS onSwitch;
    [SerializeField] private AcptLeverCS acptLever;
    [SerializeField] private DenyLeverCS denyLever;
    [SerializeField] private AcptButtonCS acptButton;
    [SerializeField] private DenyButtonCS denyButton;



    public bool consolePowered = false;
    public bool decision = false;
    public bool arrived = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getDecision()
    {

    }

}
