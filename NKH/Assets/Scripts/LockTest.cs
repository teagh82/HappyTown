using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTest : MonoBehaviour
{
    private OrderManager2 theOrder;
    private NumberSystem theNumber;

    public bool flag;
    public int correctNumber;

    // Start is called before the first frame update
    void Start()
    {
        theOrder = FindObjectOfType<OrderManager2>();
        theNumber = FindObjectOfType<NumberSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag)
        {
            StartCoroutine(ACoroutine());
        }
    }

    IEnumerator ACoroutine()
    {
        flag = true;
        theOrder.NotMove();
        theNumber.ShowNumber(correctNumber);
        yield return new WaitUntil(() => !theNumber.activated); //선택지가 끝나는 순간까지라는 의미
        theOrder.Move();
    }
}
