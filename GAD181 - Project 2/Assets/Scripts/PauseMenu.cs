using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public static bool GameIsPaused = false;

    public GameObject controlsPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        GetComponent<PlayerController>().enabled = false;
        GetComponentInChildren<PlayerPrimaryGun>().enabled = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GetComponent<PlayerController>().enabled = true;
        GetComponentInChildren<PlayerPrimaryGun>().enabled = true;
    }

    public void Instructions(int sceneID)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneID);
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneID);
    }

    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
    }
}
