﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public GameObject prefabs_Floating_Text;
    public GameObject parent;
    public GameObject effect;

    public string atkSound;

    private PlayerStat thePlayerStat;

    // Start is called before the first frame update
    void Start()
    {
        thePlayerStat = FindObjectOfType<PlayerStat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            int dmg = collision.gameObject.GetComponent<EnemyStat>().Hit(thePlayerStat.atk);
            AudioManager.instance.Play(atkSound);

            Vector3 vector = collision.transform.position;

            Instantiate(effect, vector, Quaternion.Euler(Vector3.zero));
            vector.y += 60; //머리 위에 나타나도록 함

            GameObject clone = Instantiate(prefabs_Floating_Text, vector, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingText>().text.text = dmg.ToString();  //데미지의 숫자를 텍스트에 넣어줌
            clone.GetComponent<FloatingText>().text.color = Color.white;
            clone.GetComponent<FloatingText>().text.fontSize = 25;
            clone.transform.SetParent(parent.transform);
        }   
    }

}
