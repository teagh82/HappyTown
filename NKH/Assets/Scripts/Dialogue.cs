using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(1, 2)]
    public string[] sentences; //문장들
    public Sprite[] sprites;
    public Sprite[] dialogueWindows; //대화창
}
