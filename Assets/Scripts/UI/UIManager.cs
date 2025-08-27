using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button statusButton;
    public Button inventoryButton;
    public GameObject statusPanel;
    public GameObject inventoryPanel;
    // �ڷΰ��� ��ư
    public Button backButtonInStatus; // Status_In �гο� �ִ� BackButton
    public Button backButtonInInventory; // Inventory_In �гο� �ִ� BackButton

    public static UIManager Instance { get; private set; }

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        uiMainMenu.gameObject.SetActive(true);
        // �ʱ⿡ ��� �г��� ��Ȱ��ȭ ���·� �Ӵϴ�.
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        // ��ư Ŭ�� �̺�Ʈ�� �Լ��� �����մϴ�.
        statusButton.onClick.AddListener(OnStatusButtonClick);
        inventoryButton.onClick.AddListener(OnInventoryButtonClick);
        // BackButton Ŭ�� �̺�Ʈ�� �Լ� ����
        backButtonInStatus.onClick.AddListener(OnBackButtonClick);
        backButtonInInventory.onClick.AddListener(OnBackButtonClick);
    }

    // Status ��ư Ŭ�� ��
    public void OnStatusButtonClick()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        statusPanel.SetActive(true);
    }

    // Inventory ��ư Ŭ�� ��
    public void OnInventoryButtonClick()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        inventoryPanel.SetActive(true);
    }

    // �ڷΰ��� ��ư Ŭ�� ��
    public void OnBackButtonClick()
    {
        // ��� ��ư�� �ٽ� Ȱ��ȭ�մϴ�.
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }

    public void ShowMainMenu()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiStatus.gameObject.SetActive(false); // Status UI�� ��Ȱ��ȭ
        uiInventory.gameObject.SetActive(false); // Inventory UI�� ��Ȱ��ȭ
    }

    public void ShowStatusUI()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiStatus.gameObject.SetActive(true);
        uiInventory.gameObject.SetActive(false);
    }

    public void ShowInventoryUI()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(true);

        uiInventory.Initialize();
    }
    public UIInventory GetInventoryUI()
    {
        return uiInventory;
    }

    public UIStatus GetStatusUI()
    {
        return uiStatus;
    }
}