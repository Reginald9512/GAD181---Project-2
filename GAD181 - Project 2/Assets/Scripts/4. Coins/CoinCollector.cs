using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public int coinScoreNumber;

    public AudioSource coinSoundManager;
    public AudioClip coinCollect;

    private void Start()
    {
        coinScoreNumber = 0;
        coinCount.text = coinScoreNumber.ToString();
    }

    private void Update()
    {
        if(coinScoreNumber <= 0)
        {
            coinScoreNumber = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);

            coinSoundManager.PlayOneShot(coinCollect);

            coinScoreNumber += 25;
            coinCount.text = coinScoreNumber.ToString();
        }
    }
}
