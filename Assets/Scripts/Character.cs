using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int EquippedCount { get; private set; }

    private int baseAttackPower;
    private int baseDefense;
    private int baseHealth;
    private int baseCriticalChance;

    // 아이템 인벤토리 리스트 추가
    public List<ItemData> Inventory { get; private set; }

    // 생성자 수정: Inventory 리스트 초기화
    public Character(string name, int level, int attack, int defense, int health, int critical, int gold)
    {
        CharacterName = name;
        Level = level;

        // Inventory 리스트를 가장 먼저 초기화합니다.
        Inventory = new List<ItemData>();

        AttackPower = attack;
        Defense = defense;
        Health = health;
        CriticalChance = critical;
        Gold = gold;

        // 기본 스탯을 저장합니다.
        baseAttackPower = attack;
        baseDefense = defense;
        baseHealth = health;
        baseCriticalChance = critical;

        // Inventory가 초기화된 후 RecalculateStats를 호출합니다.
        RecalculateStats();

    }

    // 아이템 추가 메서드
    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

    // 아이템 장착 메서드
    public void Equip(ItemData item)
    {
        // 새로운 아이템 장착
        item.isEquipped = true;
        AttackPower += item.attackPower;
        Defense += item.defense;
        Health += item.health;
        CriticalChance += item.criticalChance;
        RecalculateStats();


    }

    // 아이템 해제 메서드
    public void UnEquip(ItemData item)
    {
        item.isEquipped = false;
        RecalculateStats();
    }

    public void RecalculateStats()
    {
        // 스탯을 기본값으로 초기화
        AttackPower = baseAttackPower;
        Defense = baseDefense;
        Health = baseHealth;
        CriticalChance = baseCriticalChance;
        EquippedCount = 0; // 카운트 초기화

        // 장착된 아이템의 스탯을 모두 더함
        foreach (var item in Inventory)
        {
            if (item.isEquipped)
            {
                AttackPower += item.attackPower;
                Defense += item.defense;
                Health += item.health;
                CriticalChance += item.criticalChance;
                EquippedCount++; // 장착 아이템 개수 증가
            }
        }
    }
}