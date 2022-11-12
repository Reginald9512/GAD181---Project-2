using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public int coinScoreNumber;

    private void Start()
    {
        coinScoreNumber = 0;
        coinCount.text = coinScoreNumber.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);

            coinScoreNumber += 10;
            coinCount.text = coinScoreNumber.ToString();
        }
    }
}
