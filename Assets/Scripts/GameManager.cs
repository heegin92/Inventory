using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    [SerializeField] private List<ItemData> initialItems;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Player ĳ���� ����
            Player = new Character("Chad", 10, 35, 40, 100, 25, 20000);

            // ��� �������� ���� ���¸� �ʱ�ȭ�ϰ� �κ��丮�� �� ���� �߰�
            if (initialItems != null)
            {
                foreach (var item in initialItems)
                {
                    item.isEquipped = false; // ��� �������� ���� ���¸� false�� ����
                    Player.AddItem(item);
                }
            }

            // UI�� ĳ���� ���� ����
            if (uiMainMenu != null)
            {
                uiMainMenu.SetCharacterData(Player);
            }
            if (uiStatus != null)
            {
                uiStatus.SetCharacterData(Player);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �ʱ� UI ����
        UIManager.Instance.ShowMainMenu();
    }
}
