using UnityEngine;

public class CarMovementCS : MonoBehaviour
{
    // Reference scene director / synchronizer
    [SerializeField] private SceneDirectorCS syncDirector;

    // Refrence waypoints for navigation and transversal
    [SerializeField] private GameObject initialPoint;
    [SerializeField] private GameObject stopPoint;
    [SerializeField] private GameObject targetPoint;

    [SerializeField] private float speed = 3f;


    private bool pause_flg = false;

    Vector3 targetPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    { 

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if ((targetPosition == stopPoint.transform.position) && (transform.position == targetPosition))
            {
                syncDirector.arriveNotification();
                pause_flg = true;

                while (pause_flg == true) 
                { 
                    if ( syncDirector.verdict == "yes" ) 
                    { 
                        pause_flg = false; 
                        targetPosition = targetPoint.transform.position;
                    }

                    else if ( syncDirector.verdict == "no") {}
                }
            }       
            
            else if ((targetPosition == targetPoint.transform.position) && (transform.position == targetPosition))
            {
                
            } 
        }
    }

    public void InitializeObject(GameObject pointA, GameObject pointB, GameObject pointC)
    {
        // initialize waypoints / poisiton markers for navigation.
        initialPoint = pointA;
        stopPoint = pointB;
        targetPoint = pointC;

        // initialize position and target position.
        transform.position = initialPoint.transform.position;
        targetPosition = stopPoint.transform.position;
    }

}
