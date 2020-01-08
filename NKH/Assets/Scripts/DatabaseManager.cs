using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//필요한 이유: 1. A씬의 이벤트를 B에서 A로 이동할 때 중복 실행하지 않기 위해서
//2. Save와 Load 쉽게 하기 위해서
//3. 아이템을 Database에 미리 만들어두면 편하기 때문

public class DatabaseManager : MonoBehaviour
{
    static public DatabaseManager instance;
    private PlayerStat thePlayerStat;

    public GameObject prefabs__Floating_Text;
    public GameObject parent;

    private void Awake() //스타트보다 먼저 실행되는 함수
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();

    private void FloatText(int number, string color)
    {
        Vector3 vector = thePlayerStat.transform.position;
        vector.y += 60; //캐릭터 머리 위에 나타나도록 함

        GameObject clone = Instantiate(prefabs__Floating_Text, vector, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingText>().text.text = number.ToString();  //데미지의 숫자를 텍스트에 넣어줌
        if(color == "GREEN")
            clone.GetComponent<FloatingText>().text.color = Color.green;
        else if(color == "BLUE")
            clone.GetComponent<FloatingText>().text.color = Color.blue;
        clone.GetComponent<FloatingText>().text.fontSize = 25;
        clone.transform.SetParent(parent.transform);
    }

    public void UseItem(int  _itemID)
    {
        switch (_itemID)
        {
            case 10001:
                Debug.Log("hp가 20 회복되었습니다.");

                if (thePlayerStat.hp >= thePlayerStat.currentHP + 20)
                    thePlayerStat.currentHP += 20;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                FloatText(20, "GREEN");
                break;

            case 10002:
                Debug.Log("hp가 5 회복되었습니다.");

                if (thePlayerStat.hp >= thePlayerStat.currentHP + 5)
                    thePlayerStat.currentHP += 5;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                FloatText(5, "GREEN");
                break;

            default:
                break;


        }
    }

    // 아이템 추가될 때마다 여기에 입력
    void Start()
    {
        thePlayerStat = FindObjectOfType<PlayerStat>();

        //장비 
        itemList.Add(new Item(70201, "믿음", "의심을 -10 줄일 수 있다.", Item.ItemType.Equip, 0, 0, 1));    //hp가 1초마다 회복//o
        itemList.Add(new Item(70101, "심증", "기경이가 범인이라는 마을 사람들의 의심.", Item.ItemType.Equip, 1)); //사람들의 의심을 거두어들였다. 그러면 공격력 증가.//o

        //사용 아이템
        //itemList.Add(new Item(10001, "빨간 포션", "체력을 50 회복시켜 주는 신기한 물약", Item.ItemType.Use));//o
        itemList.Add(new Item(10001, "맛있는 콜라", "체력을 50 회복시켜 주는 신기한 물약", Item.ItemType.Use));//o
        itemList.Add(new Item(10002, "그저그런 파워에이드", "체력을 10 회복시켜 주는 그저그런 물약", Item.ItemType.Use));//o


        //퀘스트템
        itemList.Add(new Item(20301, "반지", "곰이의 반지", Item.ItemType.Quest));//o
        itemList.Add(new Item(40001, "봉렬이의 편지", "봉렬이가 현나에게 쓴 고백편지", Item.ItemType.Quest));//o
        itemList.Add(new Item(40002, "기경의 편지", "기경이가 봉렬이에게 쓴 고백편지", Item.ItemType.Quest));//o
        itemList.Add(new Item(40003, "곰이의 휴대폰", "곰이의 휴대폰이다.", Item.ItemType.Quest));//o
        itemList.Add(new Item(50001, "현나의 인조손톱", "현나가 얼마 전에 하고왔던 인조손톱", Item.ItemType.Quest));//o
        itemList.Add(new Item(50005, "기경이의 일기장", "너무 두꺼워서 읽고 싶지 않게 생겼다.", Item.ItemType.Quest));//o
        itemList.Add(new Item(50011, "빨간 나뭇가지", "호랑이에게 가는 길에 주운 나뭇가지", Item.ItemType.Quest));//o
        itemList.Add(new Item(50012, "피아노 학원 볼펜", "곰이네 엄마가 운영하는 피아노 학원 홍보 볼펜.", Item.ItemType.Quest));   //o 
        itemList.Add(new Item(50004, "기경이의 머리끈", "기경이가 가장 좋아하는 머리끈. 봉렬이가 줬다.", Item.ItemType.Quest));//o
        itemList.Add(new Item(40011, "호랑이의 편지", "현나에게 사과하는 편지같다.", Item.ItemType.Quest));//o

        //탈출 아이템

        itemList.Add(new Item(30003, "완전한 쿠키 조각", "칼로 과자를 자르면 2배가 된다.", Item.ItemType.ETC)); //o3
        itemList.Add(new Item(11001, "작은 상자", "움직일 때마다 딸그락 소리가 난다.", Item.ItemType.ETC));
        itemList.Add(new Item(20001, "칼", "우리나라에 딱 두개뿐인 두번째로 좋은 칼. 과자를 자를 수 있다", Item.ItemType.ETC));//o
        itemList.Add(new Item(50006, "777호 열쇠", "가장 좋은 777호 찜질방 열쇠", Item.ItemType.ETC)); // 두 글자 적혀있음//o12
        itemList.Add(new Item(50007, "귤", "식스맨 영화보고 당첨된 귀한 귤", Item.ItemType.ETC));//o4
        itemList.Add(new Item(50008, "포도", "오징어랑 포도랑 의외의 조합이라는 소문이 있다.", Item.ItemType.ETC));//o
        itemList.Add(new Item(50009, "사과", "과일가게 매출 3위인 해피 사과", Item.ItemType.ETC));//o6
        itemList.Add(new Item(50010, "앵두", "옆집 넷째 딸이 가장 좋아하는 과일", Item.ItemType.ETC));//5
        
    }
}
