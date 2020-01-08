using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToExplain : MonoBehaviour
{
    private AudioManager theAudio;

    public string click_sound;

    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
    }

    public void Click()
    {
        SceneManager.LoadScene(1);
        theAudio.Play(click_sound);
    }
}
