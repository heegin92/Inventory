using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    //[SerializeField] private TextMeshProUGUI itemNameText;
    // 빈 슬롯에 사용할 이미지를 담을 변수
    [SerializeField] private Sprite emptySlotSprite;

    // 장착 상태를 표시할 UI 이미지
    [SerializeField] private Image equipImage;
    // 장착 시 사용할 스프라이트
    [SerializeField] private Sprite equippedSprite;

    // ItemData를 담을 변수
    private ItemData itemData;

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
            //itemNameText.text = "Empty";
            equipImage.gameObject.SetActive(false);
        }
    }
}