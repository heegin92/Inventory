using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalChanceText;
    [SerializeField] private Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(() => UIManager.Instance.ShowMainMenu());
    }

    // GameManager에서 호출될 메서드: 캐릭터 정보를 받아서 UI에 표시
    public void SetCharacterData(Character character)
    {
        attackText.text = character.AttackPower.ToString();
        defenseText.text = character.Defense.ToString();
        healthText.text = character.Health.ToString();
        criticalChanceText.text = character.CriticalChance.ToString();
    }
}