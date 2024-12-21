using UnityEngine;
using TMPro;
public class YearMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text welcomeText;

    private void OnEnable()
    {
        TimeManager.OnYearPassed += ShowWelcomeMessage; 
    }
    private void OnDisable()
    {
        TimeManager.OnYearPassed -= ShowWelcomeMessage;
    }
    private void ShowWelcomeMessage(int year)
    {
        welcomeText.text = $"Hosgeldin {year:D4}";
    }
}