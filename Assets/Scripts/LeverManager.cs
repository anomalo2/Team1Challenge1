using UnityEngine;
using UnityEngine.InputSystem;

public class LeverManager : MonoBehaviour
{
    public InputActionReference grabLeft;
    public InputActionReference grabRight;

    public Collider AcceptLeverCollider;
    public Collider RejectLeverCollider;


    private void Awake()
    {
        grabLeft.action.Enable();
        grabRight.action.Enable();
        grabLeft.action.performed += AcceptLever;
        grabLeft.action.performed += RejectLever;
        grabRight.action.performed += AcceptLever;
        grabRight.action.performed += RejectLever;
    }

    private void AcceptLever(InputAction.CallbackContext context)
    {
        // Enable the collider when button is pressed
        if (AcceptLeverCollider != null) AcceptLeverCollider.enabled = true;
    }

    private void RejectLever(InputAction.CallbackContext context)
    {
        // Enable the collider when button is pressed
        if (RejectLeverCollider != null) RejectLeverCollider.enabled = true;
    }
}
