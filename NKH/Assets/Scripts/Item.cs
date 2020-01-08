using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID; //아이템의 고유 ID값, 중복 불가능
    public string itemName; //아이템의 이름, 중복 가능
    public string itemDescription; //아이템 설명
    public int itemCount; //플레이어의 아이템 소지 개수
    public Sprite itemIcon; //아이템의 아이콘(그림)
    public ItemType itemType;

    //enum = 열거, 소모품(Use)인지, Equipment(장비)인지, Quest(퀘스트)인지, ETC(기타)인지 열거 (열거된 4가지 값을 벗어난 값을 대입할 경우 오류 발생시킬 것임)
    public enum ItemType
    {
        Use,
        Equip,
        Quest,
        ETC
    }

    public int atk;
    public int def;
    public int recover_hp;
    public int recover_mp;

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, 
                int _atk = 0, int _def = 0, int _recover_hp = 0, int _recover_mp = 0, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite; //as Sprite로 캐스팅(=실제로 변환)

        atk = _atk;
        def = _def;
        recover_hp = _recover_hp;
        recover_mp = _recover_mp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
