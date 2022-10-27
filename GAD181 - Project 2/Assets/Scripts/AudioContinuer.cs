using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioContinuer : MonoBehaviour
{
    public AudioSource audioManager;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
