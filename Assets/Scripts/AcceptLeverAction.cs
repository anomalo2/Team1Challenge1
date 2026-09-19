using UnityEngine;

public class AcceptLeverAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering has a specific tag (e.g., "Player")
        if (other.gameObject.CompareTag("Game Controller"))
        {
            
            Debug.Log("Accept Lever");
        }
    }
}
