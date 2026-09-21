using UnityEngine;

public class AcceptLeverAction : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AcptLeverCS activate;

    private bool cooldown = true;

    public void CheckForExistingCollision()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        Collider[] overlaps = Physics.OverlapBox(
            box.bounds.center,
            box.bounds.extents,
            box.transform.rotation
        );

        foreach (Collider collider in overlaps)
        {
            Debug.Log("Overlap found: " + collider.tag);
            Debug.Log("compare: " + collider.CompareTag("Interactable"));
            if (collider.CompareTag("GameController"))
            {

                ActivateLever();
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Other enter: " + other.tag);
        if (other.CompareTag("GameController") && cooldown)
        {
            cooldown = false;
            ActivateLever();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Other exit: " + other.tag);
        if (other.CompareTag("GameController"))
        {
            cooldown = true;
        }
    }

    private void ActivateLever()
    {

        anim.SetTrigger("Pull lever");
        activate.ActivateAcceptLever();
    }
}