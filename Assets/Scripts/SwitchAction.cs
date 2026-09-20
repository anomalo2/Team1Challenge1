using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public Animator anim;
    public Activate activate;

    private bool cooldown = true;

    private void OnEnable()
    {
        CheckForExistingCollision();
    }

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
            if (collider.CompareTag("GameController"))
            {
                ActivateLever();
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController") && cooldown)
        {
            ActivateLever();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            cooldown = true;
        }
    }

    private void ActivateLever()
    {
        cooldown = false;

        anim.SetTrigger("Press");
        activate.ActivateAcceptLever();
    }
}
