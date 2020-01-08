using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    private NumberSystem theNum;
    private AudioManager theAudio;//추가

    public string endingSong;//추가
    public GameObject go;

    private void OnTriggerStay2D(Collider2D collision)
    {
        theNum = FindObjectOfType<NumberSystem>();
        theAudio = FindObjectOfType<AudioManager>();//추가

        if (theNum.GetResult())
        {
            go.SetActive(true);
            theAudio.Play(endingSong);//추가
        }
    }
}
