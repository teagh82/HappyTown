using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager2 : MonoBehaviour
{
    private PlayerManager thePlayer; //이벤트 도중 키 입력 처리방지
    private List<MovingObjects> characters;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    public void PreLoadCharacter()
    {
        characters = ToList();
    }

    public List<MovingObjects> ToList()
    {
        List<MovingObjects> tempList = new List<MovingObjects>();
        MovingObjects[] temp = FindObjectsOfType<MovingObjects>();

        for (int i = 0; i < temp.Length; i++)
        {
            tempList.Add(temp[i]);
        }

        return tempList;
    }

    public void NotMove()
    {
        thePlayer.notMove = true;
    }

    public void Move()
    {
        thePlayer.notMove = false;
    }

    public void SetThorought(string _name)
    {
        for(int i=0; i < characters.Count; i++)
        {
            if(_name == characters[i].characterName)
            {
                characters[i].boxCollider.enabled = false;
            }
        }
    }

    public void Move(string _name, string _dir)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].Move(_dir);
            }
        }
    }

    void Update()
    {

    }
}

