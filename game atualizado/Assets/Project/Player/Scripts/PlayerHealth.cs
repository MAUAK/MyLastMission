using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI txtHeath;

    private int currentHealth;

    public static bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        txtHeath.text = currentHealth.ToString() + "%";
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        txtHeath.text = currentHealth.ToString() + "%";

        if (currentHealth <= 0)
        {
            isDead = true;
            Cursor.visible = true;
            gameOver.SetActive(true);
        }
    }
}
