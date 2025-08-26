using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private TextMeshProUGUI characterNameText; // ĳ���� �̸� ǥ�� UI
    [SerializeField] private TextMeshProUGUI levelText;         // ���� ǥ�� UI
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        statusButton.onClick.AddListener(() => UIManager.Instance.ShowStatusUI());
        inventoryButton.onClick.AddListener(() => UIManager.Instance.ShowInventoryUI());
    }

    // GameManager���� ȣ��� �޼���: ĳ���� ������ �޾Ƽ� UI�� ǥ��
    public void SetCharacterData(Character character)
    {
        characterNameText.text = character.CharacterName;
        levelText.text = $"{character.Level}";
        goldText.text = character.Gold.ToString(); // ��� �� ������Ʈ
    }
}