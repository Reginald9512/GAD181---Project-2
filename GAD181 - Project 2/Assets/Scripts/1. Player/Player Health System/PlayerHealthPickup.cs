using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPickup : MonoBehaviour
{
    public int healthIncrease = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth += healthIncrease;
            Destroy(gameObject);
        }
    }
}