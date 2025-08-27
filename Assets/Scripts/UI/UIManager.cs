using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button statusButton;
    public Button inventoryButton;
    public GameObject statusPanel;
    public GameObject inventoryPanel;
    // 뒤로가기 버튼
    public Button backButtonInStatus; // Status_In 패널에 있는 BackButton
    public Button backButtonInInventory; // Inventory_In 패널에 있는 BackButton

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
        // 초기에 모든 패널은 비활성화 상태로 둡니다.
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        // 버튼 클릭 이벤트에 함수를 연결합니다.
        statusButton.onClick.AddListener(OnStatusButtonClick);
        inventoryButton.onClick.AddListener(OnInventoryButtonClick);
        // BackButton 클릭 이벤트에 함수 연결
        backButtonInStatus.onClick.AddListener(OnBackButtonClick);
        backButtonInInventory.onClick.AddListener(OnBackButtonClick);
    }

    // Status 버튼 클릭 시
    public void OnStatusButtonClick()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        statusPanel.SetActive(true);
    }

    // Inventory 버튼 클릭 시
    public void OnInventoryButtonClick()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        inventoryPanel.SetActive(true);
    }

    // 뒤로가기 버튼 클릭 시
    public void OnBackButtonClick()
    {
        // 모든 버튼을 다시 활성화합니다.
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }

    public void ShowMainMenu()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiStatus.gameObject.SetActive(false); // Status UI도 비활성화
        uiInventory.gameObject.SetActive(false); // Inventory UI도 비활성화
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