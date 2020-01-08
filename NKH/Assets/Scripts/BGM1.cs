using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM1 : MonoBehaviour
{
    BGMManager BGM;
    public int playMusicTrack;

    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
        //StartCoroutine(abc());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BGM.Play(playMusicTrack);
        this.gameObject.SetActive(false);
    }
}
