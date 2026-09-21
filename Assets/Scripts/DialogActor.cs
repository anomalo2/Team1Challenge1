using UnityEngine;
using TMPro;
using System.Collections;

public class DialogActor : MonoBehaviour
{
    public Dialogue normal;
    public Dialogue accept;
    public Dialogue deny;

    public TMP_Text dialogueText;
    public bool isTaliking = false;

    public Animator headAnimator;

    private Coroutine dialogueCoroutine;

    public void Start()
    {
        // DONT LEAVE THIS
        //TriggerDialogue(0); // example
    }

    public void TriggerDialogue(int diaNum)
    {
        headAnimator.SetTrigger("turn");
        Dialogue dialogue;
        if (diaNum == 0) { dialogue = normal; }
        else if (diaNum == 1) { dialogue = accept; }
        else if (diaNum == 2) { dialogue = deny; }
        else { dialogue = null; Debug.Log("needs to be 0, 1 or 2"); }

        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        if (dialogue != null) 
        { 
            isTaliking = true;
            dialogueCoroutine = StartCoroutine(PlayDialogue(dialogue));
        }

    }

    private IEnumerator PlayDialogue(Dialogue dialogue)
    {
        foreach (Line line in dialogue.lines)
        {
            dialogueText.text = line.sentence;

            yield return new WaitForSeconds(line.duration);
        }

        dialogueText.text = "";
        dialogueCoroutine = null;
        isTaliking = false;
    }
}
