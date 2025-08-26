using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private TextMeshProUGUI characterNameText; // 캐릭터 이름 표시 UI
    [SerializeField] private TextMeshProUGUI levelText;         // 레벨 표시 UI
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        statusButton.onClick.AddListener(() => UIManager.Instance.ShowStatusUI());
        inventoryButton.onClick.AddListener(() => UIManager.Instance.ShowInventoryUI());
    }

    // GameManager에서 호출될 메서드: 캐릭터 정보를 받아서 UI에 표시
    public void SetCharacterData(Character character)
    {
        characterNameText.text = character.CharacterName;
        levelText.text = $"{character.Level}";
        goldText.text = character.Gold.ToString(); // 골드 값 업데이트
    }
}