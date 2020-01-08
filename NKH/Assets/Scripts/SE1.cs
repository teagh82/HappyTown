using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE1 : MonoBehaviour
{
    SEManager SE;
    public int playMusicTrack;

    void Start()
    {
        SE = FindObjectOfType<SEManager>();
    }
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SE.Play(playMusicTrack);
    }
}
