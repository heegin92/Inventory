using System.Threading;
using UnityEngine;

// 프로젝트 메뉴에 "Create/Item Data" 항목을 추가합니다.
[CreateAssetMenu(fileName = "New Item Data", menuName = "ScriptableObjects/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int attackPower;
    public int defense;
    public bool isEquipped;

    // 아이템의 데이터를 초기화할 메서드
    public void Initialize(string name, Sprite sprite, int atk, int def)
    {
        itemName = name;
        itemSprite = sprite;
        attackPower = atk;
        defense = def;
        isEquipped = false;
    }
}