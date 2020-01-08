using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름
    private PlayerManager thePlayer;


    [Tooltip("UP, DOWN, LEFT, RIGHT")]
    public string direction; //캐릭터가 바라보고 있는 방향
    private Vector2 vector; //getFloat("dirX")를 저장하기 위한 변수



    private CameraManager theCamera;
    private OrderManager2 theOrder;
    private FadeManager theFade;



    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>(); //다수의 객체
        theCamera = FindObjectOfType<CameraManager>();
        theOrder = FindObjectOfType<OrderManager2>();
        theFade = FindObjectOfType<FadeManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(TransferCoroutine());    //Coroutine 이용해 FadeOut 이후에 대기시간을 줌
        }
    }


    IEnumerator TransferCoroutine()
    {
        theFade.FadeOut();
        yield return new WaitForSeconds(1f);
        thePlayer.currentMapName = transferMapName;
        SceneManager.LoadScene(transferMapName);
        theFade.FadeIn();
        yield return new WaitForSeconds(0.1f);
    }
}
