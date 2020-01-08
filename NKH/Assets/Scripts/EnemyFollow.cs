using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    //private EnemyFollow colleague;
    private Transform target; // enemy가 따라갈 타켓(플레이어)
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 60)
        {
            //enemy를 enemy의 위치에서 타겟의 위치로 speed만큼 움직인다. MoveTowards(from, to, speed)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetBool("Walking", true);
        }
        else if (Vector2.Distance(transform.position, target.position) <= 60)
        {
            animator.SetBool("Walking", false);
        }
    }
}
