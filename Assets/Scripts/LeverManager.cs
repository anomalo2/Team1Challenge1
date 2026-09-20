using UnityEngine;
using UnityEngine.InputSystem;

public class LeverManager : MonoBehaviour
{
    public InputActionReference grabLeft;
    public InputActionReference grabRight;

    public Collider AcceptLeverCollider;
    public Collider RejectLeverCollider;
    public Collider SwitchCollider;

    private void Awake()
    {
        grabLeft.action.Enable();
        grabRight.action.Enable();

        grabLeft.action.started += ActivateColliders;
        grabLeft.action.started += DeActivateColliders;

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
        if (AcceptLeverCollider != null) AcceptLeverCollider.enabled = true;
        if (RejectLeverCollider != null) RejectLeverCollider.enabled = true;
        if (SwitchCollider != null) SwitchCollider.enabled = true;


    }

    private void DeActivateColliders(InputAction.CallbackContext context)
    {
        // Enable the collider when button is pressed
        if (AcceptLeverCollider != null) AcceptLeverCollider.enabled = false;
        if (RejectLeverCollider != null) RejectLeverCollider.enabled = false;
        if (SwitchCollider != null) SwitchCollider.enabled = false;
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
