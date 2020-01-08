using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public float speed;
    protected Vector3 vector;
    public int walkCount;
    protected int currentWalkCount;
    public BoxCollider2D boxCollider;
    public LayerMask layerMask;
    public Animator animator;
    protected bool npcCanMove = true;
    public string characterName;

    public void Move(string _dir, int _frequency=5)
    {
        StartCoroutine(MoveCoroutine(_dir, _frequency));
    }
    
    IEnumerator MoveCoroutine(string _dir, int _frequency)
    {
        npcCanMove = false;

        vector.Set(0, 0, vector.z);
        switch(_dir)
        {
            case "UP":
                vector.y = 1f;
                break;
            case "DOWN":
                vector.y = -1f;
                break;
            case "RIGHT":
                vector.x = 1f;
                break;
            case "LEFT" :
                vector.x = -1f;
                break;
        }

        animator.SetFloat("DirX", vector.x);
        animator.SetFloat("DirY", vector.y);
        animator.SetBool("Walking", true);

        while (currentWalkCount < walkCount)
        {
            transform.Translate(vector.x * speed, vector.y * speed, 0);

            currentWalkCount++;

            yield return new WaitForSeconds(0.01f);
        }

        currentWalkCount = 0;
        if(_frequency != 5)
            animator.SetBool("Walking", false);

        npcCanMove = true;
    }

    protected bool CheckCollsion()
    {
        RaycastHit2D hit;

            Vector2 start = new Vector2(transform.position.x + vector.x * speed * walkCount, 
                                        transform.position.y + vector.y * speed * walkCount);
            Vector2 end = start + new Vector2(vector.x * speed, vector.y * speed);

            boxCollider.enabled = false;
                    hit = Physics2D.Linecast(start, end, layerMask);
                    boxCollider.enabled = true;

        if (hit.transform != null)
            return true;
        return false;
    }
}
