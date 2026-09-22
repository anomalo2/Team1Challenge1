using UnityEngine.Rendering;
using UnityEngine;
using System.Collections;

public class Lase : MonoBehaviour
{
    [SerializeField] private SyncDirectorCS syncDirector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animator;
    public AudioSource source;

    [ContextMenu("Lase")]
    public void TriggerLaser()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Lase");

        // audio
        source.GetComponent<AudioSource>();
        source.PlayDelayed(0.5f);
    }
}
