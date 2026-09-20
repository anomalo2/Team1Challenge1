using UnityEngine;

public class SyncDirectorCS : MonoBehaviour
{
    // Create a reference slot for your scripts

    [SerializeField] private GameObject vehicleObject;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private GameObject pointC;

    [SerializeField] private OnSwitchCS onSwitch;
    [SerializeField] private AcptLeverCS acptLever;
    [SerializeField] private AcptLightCS acptLight;
    [SerializeField] private DenyLeverCS denyLever;
    [SerializeField] private DenyLightCS denyLight;

    private GameObject vehicleInstance;
    private CarMovementCS vehicleCS;

    public bool consolePowered = false;
    public bool arrived = false;
    public bool decision = false;
    public string verdict = "";


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
        if ( (acptLever.select_flg == true) ) { acceptCondition(); }

        // IF passage is denied.
        else if ( (denyLever.select_flg == true) ) { rejectCondition(); }
    }

    void acceptCondition()
    {
        verdict = "accept"; 
        checkProfile();
        
        vehicleCS.go();
        reset();
        spawnVehicle();
    }

    void rejectCondition()
    {
        verdict = "reject"; 
        checkProfile();

        vehicleCS.terminate();
        reset();
        spawnVehicle();
    }

    void checkProfile()
    {
        // Check profile of the driver.
        // IF correct -> cue correct audio and green lighting.
        // IF incorrect -> cue wrong aduio and red scene lighting.

        // for unwanted /  blacklisted alien

        if ( vehicleCS.id == 1 )
        {
            if ( verdict == "reject" ) { acptLight.TurnON(); }  // correct sequence

            else if ( verdict == "accept" ) { denyLight.TurnON(); }  // incorrect sequence
        }

        // for wanted / permitted aliens

        else 
        {
            if ( verdict == "accept" ) { acptLight.TurnON(); }  // correct sequence

            else if ( verdict == "reject" ) { denyLight.TurnON(); }  // incorrect sequence
        }
    }

    void spawnVehicle()
    {
        // Spawn vehicle at initial scene.

        vehicleInstance = Instantiate(vehicleObject, pointA.transform.position, pointA.transform.rotation);

        // Get spawned instance movement script and initialize waypoints.

        vehicleCS = vehicleInstance.GetComponent<CarMovementCS>();
        vehicleCS.InitializeObject(pointA, pointB, pointC, gameObject); 
    }

    void reset() 
    {
        // Reset logic flags and verdict decision.

        arrived = false;
        decision = false;
        verdict = "";

        // Call interface element reset functions.

        acptLever.reset();
        denyLever.reset();
    }
}
