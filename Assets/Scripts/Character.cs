using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    // 기존 필드
    public string CharacterName { get; private set; }
    public int Level { get; private set; }
    public int AttackPower { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int CriticalChance { get; private set; }
    public int Gold { get; private set; }

    // 아이템 인벤토리 리스트 추가
    public List<ItemData> Inventory { get; private set; }

    // 생성자 수정: Inventory 리스트 초기화
    public Character(string name, int level, int attack, int defense, int health, int critical, int gold)
    {
        CharacterName = name;
        Level = level;
        AttackPower = attack;
        Defense = defense;
        Health = health;
        CriticalChance = critical;

        Inventory = new List<ItemData>();

        Gold = gold; // 골드 초기화
    }

    // 아이템 추가 메서드
    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

    // 아이템 장착 메서드
    public void Equip(ItemData item)
    {
        // 이미 장착된 아이템이 있다면 해제
        foreach (var invItem in Inventory)
        {
            if (invItem.isEquipped)
            {
                UnEquip(invItem);
                break;
            }
        }
        Debug.Log("Equip() 함수 호출됨: " + item.itemName);
        // 새로운 아이템 장착
        item.isEquipped = true;
        AttackPower += item.attackPower;
        Defense += item.defense;


    }

    // 아이템 해제 메서드
    public void UnEquip(ItemData item)
    {
        Debug.Log("UnEquip() 함수 호출됨: " + item.itemName);
        item.isEquipped = false;
        AttackPower -= item.attackPower;
        Defense -= item.defense;
    }
}