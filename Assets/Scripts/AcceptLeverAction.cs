using UnityEngine;

public class AcceptLeverAction : MonoBehaviour
{
    public Animator anim;
    //void Start()
    //{
        
    //    anim = GetComponent<Animator>();
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            
            Debug.Log("Accept Lever");

            anim.SetTrigger("Pull lever");
        }
    }
}
