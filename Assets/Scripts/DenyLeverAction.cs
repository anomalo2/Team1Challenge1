using UnityEngine;

public class DenyLeverAction : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {

            Debug.Log("Deny Lever");

            anim.SetTrigger("pull lever");

            //DO ACCEPT STUFF HERE. Bool? 
        }
    }
}
