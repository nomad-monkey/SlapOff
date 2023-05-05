using System;
using TMPro;
using UnityEngine;

public class HealthDisplayController : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private string healthTextString;
    [SerializeField] private HealthController healthController;

    private void Start()
    {
        DisplayHealth();
    }

    public void DisplayHealth()
    {
        healthText.text = healthTextString + healthController.Health;
    }
}
