using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private int playerHealthMax = 100;

    public GameObject gameOver;
    
    public int healthIndicator;
    [SerializeField] private TextMeshProUGUI totalPlayerhealth;

    private void Start()
    {
        playerHealth = playerHealthMax;
    }

    private void Update()
    {
        if (playerHealth > 100)
        {
            playerHealth = playerHealthMax;
        }
        
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            
            gameOver.SetActive(true);

            GetComponent<PlayerController>().enabled = false;
            GetComponent<PauseMenu>().enabled = false;
            GetComponentInChildren<PlayerPrimaryGun>().enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        totalPlayerhealth.text = playerHealth.ToString();
    }
}
