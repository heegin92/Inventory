using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private UISlot uiSlotPrefab;
    [SerializeField] private Transform slotsParent; // 슬롯의 부모(Content) 추가

    [SerializeField] private int inventorySize = 18;

    // UISlot 인스턴스들을 담을 리스트
    private List<UISlot> uiSlots = new List<UISlot>();



    private void Start()
    {
        backButton.onClick.AddListener(() => UIManager.Instance.ShowMainMenu());
    }

    // UI가 활성화될 때마다 외부에서 호출할 초기화 함수
    public void Initialize()
    {
        if (GameManager.Instance != null && GameManager.Instance.Player != null)
        {
            InitInventoryUI();
        }
        else
        {
            // 이 경고 메시지는 이제 표시되지 않아야 합니다.
            Debug.LogWarning("GameManager 또는 Player가 아직 준비되지 않았습니다. UIInventory를 초기화할 수 없습니다.");
        }
    }
    
    // InitInventoryUI() 메서드: Start()에서 호출
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

            // 인벤토리에 아이템이 있다면 아이템 데이터를 할당
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
                // 인벤토리에 아이템이 없는 경우, 빈 슬롯으로 설정
                newSlot.SetItem(null);
            }

            uiSlots.Add(newSlot);
        }
    }

    private void OnSlotClicked(ItemData item)
    {
        if (item == null) return;

        // 아이템 장착/해제 로직
        if (item.isEquipped)
        {
            GameManager.Instance.Player.UnEquip(item);
        }
        else
        {
            GameManager.Instance.Player.Equip(item);
        }

        // 모든 슬롯의 UI를 새로고침하여 장착 상태를 반영
        RefreshAllSlots();

        // 상태창 UI도 업데이트
        UIManager.Instance.ShowStatusUI();
    }

    private void RefreshAllSlots()
    {
        // 현재 인벤토리에 있는 모든 슬롯을 순회하며 UI를 새로고침합니다.
        for (int i = 0; i < uiSlots.Count; i++)
        {
            uiSlots[i].SetItem(GameManager.Instance.Player.Inventory[i]);
        }
    }

}