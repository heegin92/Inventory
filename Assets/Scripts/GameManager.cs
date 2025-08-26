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
            // Player 캐릭터 생성
            Player = new Character("Chad", 10, 35, 40, 100, 25, 20000);

            // 모든 아이템의 장착 상태를 초기화하고 인벤토리에 한 번만 추가
            if (initialItems != null)
            {
                foreach (var item in initialItems)
                {
                    item.isEquipped = false; // 모든 아이템의 장착 상태를 false로 설정
                    Player.AddItem(item);
                }
            }

            // UI에 캐릭터 정보 전달
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
        // 초기 UI 설정
        UIManager.Instance.ShowMainMenu();
    }
}
