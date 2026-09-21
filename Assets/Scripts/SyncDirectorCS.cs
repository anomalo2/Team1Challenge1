using System.Collections;
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

    [SerializeField] private IdHandler idHandler;
    [SerializeField] private signHandler signHandler;
    [SerializeField] private Lase laserVisual;
    [SerializeField] private OpenBarrier barrier;
    
    private GameObject vehicleInstance;
    private CarMovementCS vehicleCS;

    private Coroutine pauseCoroutine;

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
            signHandler.TurnON(); 
            spawnVehicle(); 
            consolePowered = true;
        }
    }

    public void arriveNotification()
    {
        if ( arrived == false) 
        { 
            arrived = true;  
            acptLight.TurnOFF(); 
            denyLight.TurnOFF(); 
            idHandler.displayModel(vehicleCS.id);
        }
    }

    public void decideNotification()
    {
        if ( decision == false ) 
        { 
            decision = true; 
            determineFate();
        }
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
        StartCoroutine(acceptSequence());
    }

    void rejectCondition()
    {
        StartCoroutine(rejectSequence());
    }


    void checkProfile()
    {
        // Check profile of the driver.
        // IF correct -> cue correct audio and green lighting.
        // IF incorrect -> cue wrong aduio and red scene lighting.

        // for unwanted /  blacklisted alien

        if ( vehicleCS.id == 0 )
        {
            // correct sequence

            if ( verdict == "reject" ) 
            { 
                acptLight.TurnON(); 
            }  

            // incorrect sequence

            else if ( verdict == "accept" ) 
            { 
                denyLight.TurnON(); 
            }  
        }

        // for wanted / permitted aliens

        else 
        {
            if ( verdict == "accept" ) 
            { 
                acptLight.TurnON(); 
            }  

            // incorrect sequence

            else if ( verdict == "reject" ) 
            { 
                denyLight.TurnON(); 
            }
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
        idHandler.reset();
    }

    IEnumerator acceptSequence()
    {

        vehicleCS.speak(1);
        while( vehicleCS.isSpeaking() ) { yield return null;  }
        
        yield return new WaitForSeconds(0.5f);

        vehicleInstance.transform.rotation = Quaternion.Euler(0f, 0f, 7.5f);
        vehicleCS.go();

        verdict = "accept"; 
        checkProfile();
        
        reset();
        spawnVehicle();
    }


    IEnumerator rejectSequence()
    {
        vehicleCS.speak(2);
        while( vehicleCS.isSpeaking() ) { yield return null;  }

        // ADD LASER TRIGGER HERE

        // EDIT THE WAIT SECONDS so car during the laser animation
        laserVisual.TriggerLaser();
        yield return new WaitForSeconds(1f);
        vehicleCS.terminate();

        verdict = "reject"; 
        checkProfile();

        reset();
        spawnVehicle();
    }
}
