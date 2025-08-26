using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int EquippedCount { get; private set; }

    private int baseAttackPower;
    private int baseDefense;
    private int baseHealth;
    private int baseCriticalChance;

    // ������ �κ��丮 ����Ʈ �߰�
    public List<ItemData> Inventory { get; private set; }

    // ������ ����: Inventory ����Ʈ �ʱ�ȭ
    public Character(string name, int level, int attack, int defense, int health, int critical, int gold)
    {
        CharacterName = name;
        Level = level;

        // Inventory ����Ʈ�� ���� ���� �ʱ�ȭ�մϴ�.
        Inventory = new List<ItemData>();

        AttackPower = attack;
        Defense = defense;
        Health = health;
        CriticalChance = critical;
        Gold = gold;

        // �⺻ ������ �����մϴ�.
        baseAttackPower = attack;
        baseDefense = defense;
        baseHealth = health;
        baseCriticalChance = critical;

        // Inventory�� �ʱ�ȭ�� �� RecalculateStats�� ȣ���մϴ�.
        RecalculateStats();

    }

    // ������ �߰� �޼���
    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

    // ������ ���� �޼���
    public void Equip(ItemData item)
    {
        // ���ο� ������ ����
        item.isEquipped = true;
        AttackPower += item.attackPower;
        Defense += item.defense;
        Health += item.health;
        CriticalChance += item.criticalChance;
        RecalculateStats();


    }

    // ������ ���� �޼���
    public void UnEquip(ItemData item)
    {
        item.isEquipped = false;
        RecalculateStats();
    }

    public void RecalculateStats()
    {
        // ������ �⺻������ �ʱ�ȭ
        AttackPower = baseAttackPower;
        Defense = baseDefense;
        Health = baseHealth;
        CriticalChance = baseCriticalChance;
        EquippedCount = 0; // ī��Ʈ �ʱ�ȭ

        // ������ �������� ������ ��� ����
        foreach (var item in Inventory)
        {
            if (item.isEquipped)
            {
                AttackPower += item.attackPower;
                Defense += item.defense;
                Health += item.health;
                CriticalChance += item.criticalChance;
                EquippedCount++; // ���� ������ ���� ����
            }
        }
    }
}