using UnityEngine;

public class SceneDirectorCS : MonoBehaviour
{
    // Create a reference slot for your scripts

    [SerializeField] private GameObject vehicleObject;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private GameObject pointC;

    [SerializeField] private OnSwitchCS onSwitch;
    [SerializeField] private AcptLeverCS acptLever;
    [SerializeField] private DenyLeverCS denyLever;
    [SerializeField] private AcptButtonCS acptButton;
    [SerializeField] private DenyButtonCS denyButton;

    private GameObject vehicleInstance;
    private CarMovementCS vehicleCS;

    public bool consolePowered = false;
    public bool decision = false;
    public bool arrived = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawnVehicle();
    }

    // Update is called once per frame
    void Update()
    {

        if (onSwitch.on_flag == true && consolePowered == false) 
        { 
            spawnVehicle(); 
            consolePowered = true;
        }
        
    }

    void spawnVehicle()
    {
        // Spawn vehicle at initial scene
        vehicleInstance = Instantiate(vehicleObject, pointA.transform.position, pointA.transform.rotation);

        // Get spawned instance movement script and initialize waypoints
        vehicleCS = vehicleInstance.GetComponent<CarMovementCS>();
        vehicleCS.InitializeObject(pointA, pointB, pointC); 
    }

    void getDecision()
    {
        
    }

}
