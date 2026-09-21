using UnityEditor.Rendering;
using UnityEngine;
using System.Collections;



public class Lase : MonoBehaviour
{
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
        source.PlayDelayed(0.2f);
    }
}
