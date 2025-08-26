using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    //[SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Sprite emptySlotSprite;

    // 장착 상태를 표시할 UI 이미지
    [SerializeField] private Image equipImage;
    // 장착 시 사용할 스프라이트
    [SerializeField] private Sprite equippedSprite;

    // ItemData를 담을 변수
    public ItemData itemData;
    private Button slotButton;

    private void Awake()
    {
        // Button 컴포넌트가 있는지 확인하고 참조
        /*slotButton = GetComponent<Button>();
        if (slotButton != null)
        {
            slotButton.onClick.AddListener(OnSlotClicked);
        }*/
    }

    // SetItem() 메서드: 외부에서 ItemData를 받아와 할당
    public void SetItem(ItemData data)
    {
        itemData = data;
        RefreshUI();
    }

    // RefreshUI() 메서드: 할당된 아이템 데이터로 UI 업데이트
    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemImage.sprite = itemData.itemSprite;
            itemImage.gameObject.SetActive(true);
            //itemNameText.text = itemData.itemName;

            // 아이템이 장착되었는지 확인하고 'Equip' 이미지 활성화/비활성화
            if (itemData.isEquipped)
            {
                equipImage.gameObject.SetActive(true);
                equipImage.sprite = equippedSprite;
            }
            else
            {
                equipImage.gameObject.SetActive(false);
            }
        }
        else
        {
            itemImage.sprite = emptySlotSprite;
            itemImage.gameObject.SetActive(true);
            //itemNameText.text = "Empty";
            equipImage.gameObject.SetActive(false);
        }
    }

    public void OnSlotClicked()
    {
        Debug.Log("UISlot 클릭됨!");
        if (itemData == null)
        {
            Debug.Log("아이템 데이터가 없습니다. 빈 슬롯입니다.");
            return;
        }

        Debug.Log("아이템: " + itemData.itemName + " 클릭됨. 현재 장착 상태: " + itemData.isEquipped);
        // 아이템 장착/해제 로직
        if (itemData.isEquipped)
        {
            GameManager.Instance.Player.UnEquip(itemData);
        }
        else
        {
            GameManager.Instance.Player.Equip(itemData);
        }
        // 인벤토리 UI와 상태창 UI를 모두 새로고침
        if (UIManager.Instance.GetInventoryUI() != null)
        {
            UIManager.Instance.GetInventoryUI().RefreshAllSlots();
        }
        if (UIManager.Instance.GetStatusUI() != null)
        {
            UIManager.Instance.GetStatusUI().SetCharacterData(GameManager.Instance.Player);
        }
    }
}