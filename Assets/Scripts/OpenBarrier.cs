using UnityEngine;

public class OpenBarrier : MonoBehaviour
{
    public Animator barranim;
    public void TriggerBarrier()
    {
        barranim.SetTrigger("open");
    }
}
