using UnityEngine;

public class AcceptLeverAction : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            
            Debug.Log("Accept Lever");

            anim.SetTrigger("Pull lever");

            //DO ACCEPT STUFF HERE. Bool? 
        }
    }
}
