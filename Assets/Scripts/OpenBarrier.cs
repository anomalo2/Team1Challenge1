using UnityEngine;

public class OpenBarrier : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    [SerializeField] private GameObject barrier;

    public Animator barranim;
    
    public void TriggerBarrier()
    {
        barranim.SetTrigger("open");
    }
}
