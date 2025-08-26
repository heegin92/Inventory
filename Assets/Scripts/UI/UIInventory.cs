using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private UISlot uiSlotPrefab;
    [SerializeField] private Transform slotsParent; // ������ �θ�(Content) �߰�
    [SerializeField] private TextMeshProUGUI equipNumText;

    [SerializeField] private int inventorySize = 18;

    // UISlot �ν��Ͻ����� ���� ����Ʈ
    private List<UISlot> uiSlots = new List<UISlot>();



    private void Start()
    {
        backButton.onClick.AddListener(() => UIManager.Instance.ShowMainMenu());
    }

    // UI�� Ȱ��ȭ�� ������ �ܺο��� ȣ���� �ʱ�ȭ �Լ�
    public void Initialize()
    {
        if (GameManager.Instance != null && GameManager.Instance.Player != null)
        {
            InitInventoryUI();
        }
        else
        {
            // �� ��� �޽����� ���� ǥ�õ��� �ʾƾ� �մϴ�.
            Debug.LogWarning("GameManager �Ǵ� Player�� ���� �غ���� �ʾҽ��ϴ�. UIInventory�� �ʱ�ȭ�� �� �����ϴ�.");
        }
    }
    
    // InitInventoryUI() �޼���: Start()���� ȣ��
    private void InitInventoryUI()
    {
        foreach (var slot in uiSlots)
        {
            Destroy(slot.gameObject);
        }
        uiSlots.Clear();

        var playerItems = GameManager.Instance.Player.Inventory;

        for (int i = 0; i < inventorySize; i++)
        {
            UISlot newSlot = Instantiate(uiSlotPrefab, slotsParent);

            // �κ��丮�� �������� �ִٸ� ������ �����͸� �Ҵ�
            if (i < playerItems.Count)
            {
                ItemData currentItem = playerItems[i];
                newSlot.SetItem(currentItem);

                Button slotButton = newSlot.GetComponent<Button>();
                if (slotButton != null)
                {
                    slotButton.onClick.AddListener(() => OnSlotClicked(currentItem));
                }
            }
            else
            {
                // �κ��丮�� �������� ���� ���, �� �������� ����
                newSlot.SetItem(null);
            }

            uiSlots.Add(newSlot);
        }
    }

    private void OnSlotClicked(ItemData item)
    {
        if (item == null) return;

        // ������ ����/���� ����
        if (item.isEquipped)
        {
            GameManager.Instance.Player.UnEquip(item);
        }
        else
        {
            GameManager.Instance.Player.Equip(item);
        }

        // ��� ������ UI�� ���ΰ�ħ�Ͽ� ���� ���¸� �ݿ�
        RefreshAllSlots();

        // ����â UI�� ������Ʈ
        UIManager.Instance.ShowStatusUI();
    }

    public void RefreshAllSlots()
    {
        int equippedCount = 0;

        for (int i = 0; i < uiSlots.Count; i++)
        {
            if (i < GameManager.Instance.Player.Inventory.Count)
            {
                ItemData currentItem = GameManager.Instance.Player.Inventory[i];
                uiSlots[i].SetItem(currentItem);

                // ������ �������̸� ī��Ʈ ����
                if (currentItem.isEquipped)
                {
                    equippedCount++;
                }
            }
            else
            {
                uiSlots[i].SetItem(null);
            }

            equipNumText.text = equippedCount.ToString();
        }
    }


}