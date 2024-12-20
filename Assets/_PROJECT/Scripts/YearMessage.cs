using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class YearMessage : MonoBehaviour
{
    public TMP_Text welcomeText; // Hoşgeldin mesajı için UI Text

    private void OnEnable()
    {
        TimeManager.OnYearPassed += ShowWelcomeMessage; // Event dinleyiciyi ekle
    }

    private void OnDisable()
    {
        TimeManager.OnYearPassed -= ShowWelcomeMessage; // Event dinleyiciyi çıkar
    }

    private void ShowWelcomeMessage(int year)
    {
        welcomeText.text = $"Hoşgeldin {year:D4}"; // 0000 formatında yıl
    }
}