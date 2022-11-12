using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthButton1;
    public GameObject healthButton2;
    public GameObject healthButton3;

    public TextMeshProUGUI coinCount;
    public int coinScoreNumber;

    public AudioSource buttonSoundManager;
    public AudioClip healthSound;

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

    //Health Upgrade
    public void MoreHealth1()
    {
        if (gameObject.GetComponentInParent<CoinCollector>().coinScoreNumber >= 200)
        {
            buttonSoundManager.PlayOneShot(healthSound);

            playerHealthMax = 150;
            playerHealth = 150;

            healthButton1.SetActive(false);
            healthButton2.SetActive(true);

            gameObject.GetComponentInParent<CoinCollector>().coinScoreNumber -= 200;
            coinCount.text = coinScoreNumber.ToString();
        }
    }
    public void MoreHealth2()
    {
        if (gameObject.GetComponentInParent<CoinCollector>().coinScoreNumber >= 400)
        {
            buttonSoundManager.PlayOneShot(healthSound);

            playerHealthMax = 200;
            playerHealth = 200;

            healthButton2.SetActive(false);
            healthButton3.SetActive(true);

            gameObject.GetComponentInParent<CoinCollector>().coinScoreNumber -= 400;
            coinCount.text = coinScoreNumber.ToString();
        }       
    }
}
