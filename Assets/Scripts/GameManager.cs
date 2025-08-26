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

            // ��� �����ʹ� Awake���� �ʱ�ȭ�Ͽ� �ٸ� ��ũ��Ʈ�� Start���� ������ �� �ֵ��� ��
            SetData();
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

    // SetData() �޼���: ĳ���͸� �����ϰ� UI�� �����͸� �����մϴ�.
    private void SetData()
    {
        // Player ĳ���� ����
        Player = new Character("Chad", 10, 35, 40, 100, 25, 20000);

        // �κ��丮 ������ �߰�
        if (initialItems != null)
        {
            foreach (var item in initialItems)
            {
                Player.AddItem(item);
            }
        }

        // UI�� ĳ���� ���� ����
        uiMainMenu.SetCharacterData(Player);
        uiStatus.SetCharacterData(Player);
    }
}
