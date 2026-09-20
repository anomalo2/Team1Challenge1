using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {

            Debug.Log("Switch");

            anim.SetTrigger("Press");

            //START. Bool? 
        }
    }
}
