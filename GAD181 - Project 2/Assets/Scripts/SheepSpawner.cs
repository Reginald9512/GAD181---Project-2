using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheep1;
    public GameObject sheep2;
    public GameObject sheep3;
    public GameObject sheep4;
    public GameObject sheep5;
    public GameObject sheep6;
    public GameObject sheep7;

    public GameObject sheepDisplay1;
    public GameObject sheepDisplay2;

    public GameObject upgradeShopButton;

    public AudioClip coinSound;
    public AudioClip sheepSound;
    public AudioClip gateSound;

    public TextMeshProUGUI sheepScore;
    public TextMeshProUGUI coinScore;

    public int sheepScoreNumber;
    public int coinScoreNumber;

    bool active;
    private bool boosting;

    void Start()
    {
        sheep1.SetActive(true);
        sheep2.SetActive(true);
        sheep3.SetActive(true);
        sheep4.SetActive(true);
        sheep5.SetActive(true);
        sheep6.SetActive(true);
        sheep7.SetActive(true);

        sheepScoreNumber = 7;
        sheepScore.text = sheepScoreNumber.ToString();
        coinScoreNumber = 0;
        coinScore.text = coinScoreNumber.ToString();

        //gameObject.GetComponent<SUPERCharacter.SUPERCharacterAIO>().walkingSpeed = 300;
        //gameObject.GetComponent<SUPERCharacter.SUPERCharacterAIO>().sprintingSpeed = 500;

        boosting = false;
    }

    public void Update()
    {
        if (boosting)
        {
            //gameObject.GetComponent<SUPERCharacter.SUPERCharacterAIO>().walkingSpeed = 900;
            //gameObject.GetComponent<SUPERCharacter.SUPERCharacterAIO>().sprintingSpeed = 1200;

            boosting = true;

            Debug.Log("You're Running Really Fast!");
        }
    }

    public void speedBoost()
    {
        boosting = true;

        coinScoreNumber -= 10;
        coinScore.text = coinScoreNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {
            other.gameObject.SetActive(false);

            gameObject.GetComponent<AudioSource>().PlayOneShot(sheepSound);

            --sheepScoreNumber;
            sheepScore.text = sheepScoreNumber.ToString();
        }

        if (other.gameObject.CompareTag("Farmer"))
        {
            if(sheepScoreNumber <= 0)
            {
                upgradeShopButton.SetActive(true);
                sheepDisplay1.SetActive(true);
                sheepDisplay2.SetActive(true);

                coinScoreNumber += 10;
                coinScore.text = coinScoreNumber.ToString();

                gameObject.GetComponent<AudioSource>().PlayOneShot(coinSound);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Farmer"))
        {
            if(sheepScoreNumber <= 0)
            {
                upgradeShopButton.SetActive(false);

                gameObject.GetComponent<AudioSource>().PlayOneShot(gateSound);

                sheep1.SetActive(true);
                sheep2.SetActive(true);
                sheep3.SetActive(true);
                sheep4.SetActive(true);
                sheep5.SetActive(true);
                sheep6.SetActive(true);
                sheep7.SetActive(true);

                sheepDisplay1.SetActive(false);
                sheepDisplay2.SetActive(false);

                sheepScoreNumber = 7;
                sheepScore.text = sheepScoreNumber.ToString();
            }
        }
    }
}

