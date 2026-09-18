using UnityEngine;

public class ModelDisplacement : MonoBehaviour
{
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform mainCam;

    private Vector3 initialCameraLocalPosition;
    private Vector3 initialCharacterLocalPosition;

    private void Start()
    {
        initialCameraLocalPosition = xrOrigin.InverseTransformPoint(mainCam.position);
        initialCharacterLocalPosition = transform.localPosition;
    }

    private void LateUpdate()
    {
        Vector3 cameraLocalPosition =
            xrOrigin.InverseTransformPoint(mainCam.position);

        Vector3 displacement =
            cameraLocalPosition - initialCameraLocalPosition;

        // lock vertical movement
        displacement.y = 0f;

        transform.localPosition =
            initialCharacterLocalPosition + displacement;
    }
}
