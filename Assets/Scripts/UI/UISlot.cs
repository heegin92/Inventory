using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    //[SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Sprite emptySlotSprite;

    // ���� ���¸� ǥ���� UI �̹���
    [SerializeField] private Image equipImage;
    // ���� �� ����� ��������Ʈ
    [SerializeField] private Sprite equippedSprite;

    // ItemData�� ���� ����
    public ItemData itemData;
    private Button slotButton;

    private void Awake()
    {
        // Button ������Ʈ�� �ִ��� Ȯ���ϰ� ����
        /*slotButton = GetComponent<Button>();
        if (slotButton != null)
        {
            slotButton.onClick.AddListener(OnSlotClicked);
        }*/
    }

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
            itemImage.gameObject.SetActive(true);
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
            itemImage.gameObject.SetActive(true);
            //itemNameText.text = "Empty";
            equipImage.gameObject.SetActive(false);
        }
    }

    public void OnSlotClicked()
    {
        Debug.Log("UISlot Ŭ����!");
        if (itemData == null)
        {
            Debug.Log("������ �����Ͱ� �����ϴ�. �� �����Դϴ�.");
            return;
        }

        Debug.Log("������: " + itemData.itemName + " Ŭ����. ���� ���� ����: " + itemData.isEquipped);
        // ������ ����/���� ����
        if (itemData.isEquipped)
        {
            GameManager.Instance.Player.UnEquip(itemData);
        }
        else
        {
            GameManager.Instance.Player.Equip(itemData);
        }
        // �κ��丮 UI�� ����â UI�� ��� ���ΰ�ħ
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