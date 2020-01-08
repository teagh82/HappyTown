using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSTest : MonoBehaviour
{
    [SerializeField]
    public Choice choice;
    private OrderManager2 theOrder;
    private ChoiceManager theChoice;

    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        theOrder = FindObjectOfType<OrderManager2>();
        theChoice = FindObjectOfType<ChoiceManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!flag)
        {
            StartCoroutine(ACoroutine());
        }
    }

    IEnumerator ACoroutine()
    {
        flag = true;
        theOrder.NotMove();
        theChoice.ShowChoice(choice);
        yield return new WaitUntil(() => !theChoice.choiceIng); //선택지가 끝나는 순간까지라는 의미
        theOrder.Move();
        Debug.Log(theChoice.GetResult()); //선택됐는지 보여주려고
    }
}
