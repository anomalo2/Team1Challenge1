using UnityEngine;

public class CarMovementCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SyncDirectorCS syncDirector;

    // Reference for alein and car models
    [SerializeField] private GameObject[] alienModel; 
    [SerializeField] private DialogActor dialogCS;

    // Refrence waypoints / positions for navigation and transversal
    [SerializeField] private GameObject initialPoint;
    [SerializeField] private GameObject stopPoint;
    [SerializeField] private GameObject targetPoint;

    [SerializeField] private float speed = 3f;

    public int id;

    Vector3 targetPosition;


    void Start() 
    { 
        InitializeModel();
    }

    void Update()
    {
        // Move towards target position.

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Snap to target position.

            transform.position = targetPosition; 

            // IF at StopPoint halt until manager gives a verdict.

            if ((targetPosition == stopPoint.transform.position))
            {
                speak(0);
                if ( !isSpeaking() ) { syncDirector.arriveNotification(); }
            }    
            
            // IF arrived at TargetPoint terminate instance.

            else if ((targetPosition == targetPoint.transform.position))
            {
                terminate();
            } 
        }

    }

    public void InitializeObject(GameObject pointA, GameObject pointB, GameObject pointC, GameObject sceneManager)
    {
        // initialize scene / sync director

        syncDirector = sceneManager.GetComponent<SyncDirectorCS>();

        // initialize waypoints / poisiton markers for navigation.

        initialPoint = pointA;
        stopPoint = pointB;
        targetPoint = pointC;

        // initialize position and target position.

        transform.position = initialPoint.transform.position;
        targetPosition = stopPoint.transform.position;
    }

    public void InitializeModel()
    {
        // assign id and corresponding model.

        id = Random.Range(0, alienModel.Length);
        alienModel[id].SetActive(true);
        dialogCS = alienModel[id].GetComponent<AlienAssets>().dialogScript;
    }

    public bool isSpeaking() { return dialogCS.isTaliking; }

    public void speak(int condition) { dialogCS.TriggerDialogue(condition); }

    public void go() { targetPosition = targetPoint.transform.position; }

    public void terminate() { Destroy(gameObject); }

}
