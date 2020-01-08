using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDial : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;
    private DialogueManager theDM;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && stop == false)
        {
            theDM.ShowDialogue(dialogue);
        }

        stop = true;
    }
}
