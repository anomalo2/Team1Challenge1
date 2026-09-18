using UnityEngine;

public class DemoMovementScript : MonoBehaviour
{
    [SerializeField] private GameObject initialPoint;
    [SerializeField] private GameObject stopPoint;
    [SerializeField] private GameObject targetPoint;

    [SerializeField] private float speed = 3f;
    [SerializeField] private int countInit = 1000;


    private int waitCount;
    private bool pause_flag = true;

    Vector3 targetPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    { 
        waitCount = countInit;
        initalize_object();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)

        {
            transform.position = targetPosition; 
            pause_flag = false;             
        }
        
        if ((targetPosition == stopPoint.transform.position) && (transform.position == targetPosition))
        {
            waitCount -= 1;
            if (waitCount <= 0) { targetPosition = targetPoint.transform.position; }
        }

        else if ((targetPosition == targetPoint.transform.position) && (transform.position == targetPosition))
        {
            waitCount = countInit;
            initalize_object();
        }
    }

    void initalize_object()
    {
        transform.position = initialPoint.transform.position;
        targetPosition = stopPoint.transform.position;
    }

}
