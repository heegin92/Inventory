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

            // 모든 데이터는 Awake에서 초기화하여 다른 스크립트가 Start에서 참조할 수 있도록 함
            SetData();
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

    // SetData() 메서드: 캐릭터를 생성하고 UI에 데이터를 전달합니다.
    private void SetData()
    {
        // Player 캐릭터 생성
        Player = new Character("Chad", 10, 35, 40, 100, 25, 20000);

        // 인벤토리 아이템 추가
        if (initialItems != null)
        {
            foreach (var item in initialItems)
            {
                Player.AddItem(item);
            }
        }

        // UI에 캐릭터 정보 전달
        uiMainMenu.SetCharacterData(Player);
        uiStatus.SetCharacterData(Player);
    }
}
