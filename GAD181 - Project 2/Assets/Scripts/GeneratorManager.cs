using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneratorManager : MonoBehaviour
{
    public GameObject gameOver;

    public AudioClip collectSound;
    public AudioSource generatorSounds;
    
    public TextMeshProUGUI fuelCount;

    public float timeLeft = 100.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;

        fuelCount.text = (timeLeft).ToString("0");

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PauseMenu>().enabled = false;
            GetComponentInChildren<PlayerPrimaryGun>().enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            gameOver.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            other.gameObject.SetActive(false);

            generatorSounds.PlayOneShot(collectSound);

            timeLeft += 10;
            fuelCount.text = (timeLeft).ToString("0");
        }
    }
}
