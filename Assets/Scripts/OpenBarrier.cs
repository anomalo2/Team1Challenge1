using UnityEngine;

public class OpenBarrier : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;

    public Animator barranim;
    
    public void TriggerBarrier()
    {
        barranim.SetTrigger("open");
    }
}
