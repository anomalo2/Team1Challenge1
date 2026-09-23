using System.Collections;
using UnityEngine;

public class OpenBarrier : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    [SerializeField] private GameObject barrier;

    private Quaternion openRotation;
    private Quaternion closedRotation;

    private bool open = false;
    private float degrees = 5f;

    public Animator barranim;

    void start()
    {
        openRotation = Quaternion.Euler(0f, 0f, 0f);
        closedRotation = Quaternion.Euler(90f, 0f, 0f);
    }
    
    void Update()
    {
        if( open )
        {
            barrier.transform.rotation = Quaternion.RotateTowards(barrier.transform.rotation, openRotation, degrees * Time.deltaTime);
            if (Quaternion.Angle(barrier.transform.rotation, openRotation) < 0.01f) { barrier.transform.rotation = openRotation; }
        }

        else
        {
            barrier.transform.rotation = Quaternion.RotateTowards(barrier.transform.rotation, closedRotation, degrees * Time.deltaTime);
            if (Quaternion.Angle(barrier.transform.rotation, closedRotation) < 0.01f) { barrier.transform.rotation = closedRotation; }
        }
    }

    public void TriggerBarrier()
    {
        barranim.SetTrigger("open");
    }

    public void openBarrier() { open = true; }

    public void closeBarrier() { open = false; }
}
