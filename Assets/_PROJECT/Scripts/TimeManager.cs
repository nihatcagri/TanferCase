using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public TMP_Text timeText; // Oyun içindeki zaman için UI Text
    public static event Action<int> OnYearPassed; // Yıl geçtiğinde tetiklenecek event

    private float elapsedTime = 0f; // Geçen zamanı hesaplar
    private int year = 0; // Yıl sayacı
    private int month = 0; // Ay sayacı

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.5f) // 0.5 saniye bir ay
        {
            elapsedTime = 0f; // Zamanı sıfırla
            month++;

            if (month > 12) // Yeni yıla geçiş
            {
                month = 1; // Ayı sıfırla
                year++; // Yılı artır
                OnYearPassed?.Invoke(year); // Eventi tetikle
            }

            UpdateTimeUI(); // UI güncelle
        }
    }

    private void UpdateTimeUI()
    {
        timeText.text = $"{year:D4}.{month:D2}"; // 0000.00 formatında göster
    }
}
