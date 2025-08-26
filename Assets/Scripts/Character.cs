using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    // ���� �ʵ�
    public string CharacterName { get; private set; }
    public int Level { get; private set; }
    public int AttackPower { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int CriticalChance { get; private set; }
    public int Gold { get; private set; }

    // ������ �κ��丮 ����Ʈ �߰�
    public List<ItemData> Inventory { get; private set; }

    // ������ ����: Inventory ����Ʈ �ʱ�ȭ
    public Character(string name, int level, int attack, int defense, int health, int critical, int gold)
    {
        CharacterName = name;
        Level = level;
        AttackPower = attack;
        Defense = defense;
        Health = health;
        CriticalChance = critical;

        Inventory = new List<ItemData>();

        Gold = gold; // ��� �ʱ�ȭ
    }

    // ������ �߰� �޼���
    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

    // ������ ���� �޼���
    public void Equip(ItemData item)
    {
        // �̹� ������ �������� �ִٸ� ����
        foreach (var invItem in Inventory)
        {
            if (invItem.isEquipped)
            {
                UnEquip(invItem);
                break;
            }
        }
        Debug.Log("Equip() �Լ� ȣ���: " + item.itemName);
        // ���ο� ������ ����
        item.isEquipped = true;
        AttackPower += item.attackPower;
        Defense += item.defense;


    }

    // ������ ���� �޼���
    public void UnEquip(ItemData item)
    {
        Debug.Log("UnEquip() �Լ� ȣ���: " + item.itemName);
        item.isEquipped = false;
        AttackPower -= item.attackPower;
        Defense -= item.defense;
    }
}