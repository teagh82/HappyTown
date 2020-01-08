using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{

    public float moveSpeed; // 텍스트가 떠다니는 속도 
    public float destroyTime; // 텍스트가 계속 떠다니는 걸 방지(일정한 시간 후 파괴)

    public Text text;

    private Vector3 vector; // 포지션값 조정 위해 필요한 벡터변수  

    void Update()
    {
        vector.Set(text.transform.position.x, text.transform.position.y + (moveSpeed * Time.deltaTime), text.transform.position.z);
        text.transform.position = vector;

        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
            Destroy(this.gameObject);
    }
}