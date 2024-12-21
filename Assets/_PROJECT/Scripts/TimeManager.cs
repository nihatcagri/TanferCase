using System;
using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText; 
    public static event Action<int> OnYearPassed; 
    
    private float elapsedTime = 0f; 
    private int year = 0; 
    private int month = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.5f) 
        {
            elapsedTime = 0f; 
            month++;
            AudioManager.Instance.PlaySound(0);

            if (month > 12) 
            {
                month = 1;
                year++; 
                ParticleManager.Instance.FlashParticle();
                AudioManager.Instance.PlaySound(2);
                OnYearPassed?.Invoke(year); 
            }

            UpdateTimeUI();
        }
    }

    public void ResetTime() 
    {
        year = 0;
        month = 0;
        elapsedTime = 0f; 
        OnYearPassed?.Invoke(year); 
        UpdateTimeUI();
        AudioManager.Instance.PlaySound(1);
    }
    private void UpdateTimeUI()
    {
        timeText.text = $"{year:D4}.{month:D2}";
    }
}
