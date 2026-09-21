using UnityEngine;
using UnityEngine.InputSystem;

public class HandGrab : MonoBehaviour
{
    public InputActionReference grabLeft;
    public InputActionReference grabRight;

    public Animator handAnim;
    public AudioSource leftsource;
    public AudioSource rightsource;

    private void Awake()
    {
        grabLeft.action.Enable();
        grabRight.action.Enable();

        grabLeft.action.started += LeftGrab;
        grabLeft.action.canceled += LeftGrabStop;

        grabRight.action.started += RightGrab;
        grabRight.action.canceled += RightGrabStop;
    }

    private void LeftGrab(InputAction.CallbackContext context)
    {
        handAnim.SetBool("LeftGrab", true);
        leftsource.Play();
    }
    private void LeftGrabStop(InputAction.CallbackContext context)
    {
        handAnim.SetBool("LeftGrab", false);
    }

    private void RightGrab(InputAction.CallbackContext context)
    {
        handAnim.SetBool("rGrab", true);
        rightsource.Play();
    }

    private void RightGrabStop(InputAction.CallbackContext context)
    {
        handAnim.SetBool("rGrab", false);
    }
}
