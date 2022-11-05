using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public int killboxDamage = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= killboxDamage;
        }
    }
}
