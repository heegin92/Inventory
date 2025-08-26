using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    //[SerializeField] private TextMeshProUGUI itemNameText;
    // �� ���Կ� ����� �̹����� ���� ����
    [SerializeField] private Sprite emptySlotSprite;

    // ���� ���¸� ǥ���� UI �̹���
    [SerializeField] private Image equipImage;
    // ���� �� ����� ��������Ʈ
    [SerializeField] private Sprite equippedSprite;

    // ItemData�� ���� ����
    private ItemData itemData;

    // SetItem() �޼���: �ܺο��� ItemData�� �޾ƿ� �Ҵ�
    public void SetItem(ItemData data)
    {
        itemData = data;
        RefreshUI();
    }

    // RefreshUI() �޼���: �Ҵ�� ������ �����ͷ� UI ������Ʈ
    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemImage.sprite = itemData.itemSprite;
            //itemNameText.text = itemData.itemName;

            // �������� �����Ǿ����� Ȯ���ϰ� 'Equip' �̹��� Ȱ��ȭ/��Ȱ��ȭ
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