using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MovingObjects
{
    public float attackDelay; // 공격 전 플레이어가 피할 수 있도록 약간의 지연 시간(공격 유예) 

    public float inter_MoveWaitTime; // 이동하기 전 대기하는 시간 (인스펙터에서 유저가 넣어주는 값) 
    private float current_interMWT; // 실제로 이 변수로 계산  

    public string atkSound;

    private Vector2 playerPos; // 슬라임 공격 발동 거리(플레이어와 슬라임의 거리를 좌표값으로)

    private int random_int; // 슬라임이 랜덤으로 움직이기 위한 변수 
    private string direction; // Move() 함수의 reference 

    public GameObject healthBar;

    void Start()
    {
        Queue<string> queue = new Queue<string>();
        current_interMWT = inter_MoveWaitTime;
    }

    void Update()
    {
        current_interMWT -= Time.deltaTime;

        if (current_interMWT <= 0)
        {
            current_interMWT = inter_MoveWaitTime;

            if (NearPlayer())
            {
                Flip();
                return;
            }

            RandomDirection();

            if (base.CheckCollsion()) // 충돌 체크(앞에 뭐가 있는 지) 
                return;

            base.Move(direction);
        }
    }

    private void Flip() // 슬라임 왼쪽 공격 애니메이션밖에 없지만 scale x값 -1 해주면 오른쪽으로 뒤집힘 
    {
        Vector3 flip = transform.localScale;
        if (playerPos.x > this.transform.position.x)
            flip.x = -1f;
        else
            flip.x = 1f;
        this.transform.localScale = flip;

        healthBar.transform.localScale = flip;

        animator.SetTrigger("Attack");
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine() // 공격 유예동안 공격하지 않도록(40프레임 이전이니 0.4f 대기) 
    {
        yield return new WaitForSeconds(attackDelay);
        AudioManager.instance.Play(atkSound);
        if (NearPlayer()) // 약간 대기한 후에도 캐릭터가 여전히 그 자리에 있는지 확인  
            PlayerStat.instance.Hit(GetComponent<EnemyStat>().atk);
    }

    private bool NearPlayer() // 공격 함수 中 플레이어가 근처에 있는지 
    {
        playerPos = PlayerManager.instance.transform.position;

        if (Mathf.Abs(Mathf.Abs(playerPos.x) - Mathf.Abs(this.transform.position.x)) <= speed * walkCount * 1.01f) // 플레이어와 슬라임의 위치를 뺀 값이 48 이하일 경우
        {
            if (Mathf.Abs(Mathf.Abs(playerPos.y) - Mathf.Abs(this.transform.position.y)) <= speed * walkCount * 0.5f)
            {
                return true;
            }
        }
        if (Mathf.Abs(Mathf.Abs(playerPos.y) - Mathf.Abs(this.transform.position.y)) <= speed * walkCount * 1.01f) // 플레이어와 슬라임의 위치를 뺀 값이 48 이하일 경우
        {
            if (Mathf.Abs(Mathf.Abs(playerPos.x) - Mathf.Abs(this.transform.position.x)) <= speed * walkCount * 0.5f)
            {
                return true;
            }
        }

        return false;
    }

    private void RandomDirection()
    {
        vector.Set(0, 0, vector.z);
        random_int = Random.Range(0, 4); // 0, 1, 2, 3
        switch (random_int)
        {
            case 0:
                vector.y = 1f;
                direction = "UP";
                break;
            case 1:
                vector.y = -1f;
                direction = "DOWN";
                break;
            case 2:
                vector.x = 1f;
                direction = "RIGHT";
                break;
            case 3:
                vector.x = -1f;
                direction = "LEFT";
                break;
        }
    }
}
