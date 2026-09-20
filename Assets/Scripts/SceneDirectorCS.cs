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
    public bool arrived = false;
    public bool decision = false;
    public string verdict;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start() { }

    // Update is called once per frame
    // void Update() { }

    public void powerNotification()
    {
        if ( consolePowered == false ) 
        { 
            spawnVehicle(); 
            consolePowered = true;
        }
    }

    public void arriveNotification()
    {
        if ( arrived == false) { arrived = true; }
    }

    public void decideNotification()
    {
        if ( decision == false ) { decision = true; }
        determineFate();
    }

    void determineFate()
    {
        // IF passage is approved.
        if ( acptLever.select_flg == true || acptButton.select_flg == true ) { verdict = "yes"; }

        // IF passage is denied.
        else if ( denyLever.select_flg == true || denyButton.select_flg == true ) { verdict = "no"; }
    }

    void spawnVehicle()
    {
        // Spawn vehicle at initial scene
        vehicleInstance = Instantiate(vehicleObject, pointA.transform.position, pointA.transform.rotation);

        // Get spawned instance movement script and initialize waypoints
        vehicleCS = vehicleInstance.GetComponent<CarMovementCS>();
        vehicleCS.InitializeObject(pointA, pointB, pointC); 
    }

    void reset() 
    {
        // reset logic flags and verdict decision.
        arrived = false;
        decision = false;
        verdict = "";

        // call interface element reset functions.
        acptLever.reset();
        denyLever.reset();
        acptButton.reset();
        denyButton.reset();
    }

}
