using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LeverManager : MonoBehaviour
{
    public InputActionReference grabLeft;
    public InputActionReference grabRight;

    public GameObject AcceptLeverCollider;
    public GameObject RejectLeverCollider;
    public GameObject SwitchCollider;

    [SerializeField] private float deactivateDelay = 0.1f;

    private void Awake()
    {
        grabLeft.action.Enable();
        grabRight.action.Enable();

        grabLeft.action.started += ActivateColliders;
        grabLeft.action.canceled += DeActivateColliders;

        grabRight.action.started += ActivateColliders;
        grabRight.action.canceled += DeActivateColliders;

        //grabLeft.action.started += AcceptLever;
        //grabLeft.action.started += RejectLever;
        //grabRight.action.started += AcceptLever;
        //grabRight.action.started += RejectLever;

        //grabLeft.action.canceled += AcceptLeverStop;
        //grabLeft.action.canceled += RejectLeverStop;
        //grabRight.action.canceled += AcceptLeverStop;
        //grabRight.action.canceled += RejectLeverStop;
    }

    private void ActivateColliders(InputAction.CallbackContext context)
    {
        // Enable the collider when button is pressed
        if (AcceptLeverCollider != null)
        {
            AcceptLeverCollider.GetComponent<Collider>().enabled = true;

            AcceptLeverCollider
                .GetComponent<AcceptLeverAction>()
                .CheckForExistingCollision();
        }

        //if (RejectLeverCollider != null) RejectLeverCollider.enabled = true;
        if (RejectLeverCollider != null)
        {
            RejectLeverCollider.GetComponent<Collider>().enabled = true;

            RejectLeverCollider
                .GetComponent<DenyLeverAction>()
                .CheckForExistingCollision();
        }

        //if (SwitchCollider != null) SwitchCollider.enabled = true;
        if (SwitchCollider != null)
        {
            SwitchCollider.GetComponent<Collider>().enabled = true;

            SwitchCollider
                .GetComponent<SwitchAction>()
                .CheckForExistingCollision();
        }

    }

    private Coroutine deactivateCoroutine;
    private void DeActivateColliders(InputAction.CallbackContext context)
    {
        if (deactivateCoroutine != null)
            StopCoroutine(deactivateCoroutine);

        deactivateCoroutine = StartCoroutine(DeactivateAfterDelay());
    }

    private IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(deactivateDelay);

        if (AcceptLeverCollider != null)
            AcceptLeverCollider.GetComponent<Collider>().enabled = false;

        if (RejectLeverCollider != null)
            RejectLeverCollider.GetComponent<Collider>().enabled = false;

        if (SwitchCollider != null)
            SwitchCollider.GetComponent<Collider>().enabled = false;

        deactivateCoroutine = null;
    }


    //private void AcceptLever(InputAction.CallbackContext context)
    //{
    //    // Enable the collider when button is pressed
    //    if (AcceptLeverCollider != null) AcceptLeverCollider.enabled = true;


    //}

    //private void AcceptLeverStop(InputAction.CallbackContext context)
    //{
    //    // Enable the collider when button is pressed
    //    if (AcceptLeverCollider != null) AcceptLeverCollider.enabled = false;
    //}

    //private void RejectLever(InputAction.CallbackContext context)
    //{
    //    // Enable the collider when button is pressed
    //    if (RejectLeverCollider != null) RejectLeverCollider.enabled = true;
    //}

    //private void RejectLeverStop(InputAction.CallbackContext context)
    //{
    //    // Enable the collider when button is pressed
    //    if (RejectLeverCollider != null) RejectLeverCollider.enabled = true;
    //}
}
