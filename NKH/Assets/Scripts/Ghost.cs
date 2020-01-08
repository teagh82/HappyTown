using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostMove
{
    [Tooltip("NPCmove를 체크하면 NPC가 움직임")]
    public bool NPCmove;
}

public class Ghost : MovingObjects
{
    [SerializeField]
    public GhostMove ghost;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }
    
    public void setMove()
    {
       
    }
    public void setNotMove()
    {

    }

    IEnumerator MoveCoroutine()
    {
        int frequency = 5;

        while (true) { 
            int dir = Random.Range(0, 4);
                yield return new WaitUntil(() => npcCanMove); //npcCanMove가 ture일때까지, coroutine 끝나자마자 base 실행

            //실질적인 이동 부분
            switch (dir)
            {
                case 0:
                    base.Move("UP", frequency);
                    break;
                case 1:
                    base.Move("DOWN", frequency);
                    break;
                case 2:
                    base.Move("RIGHT", frequency);
                    break;
                case 3:
                    base.Move("LEFT", frequency);                  
                    break;
                default:
                    break;
            }
        }
    }
}
