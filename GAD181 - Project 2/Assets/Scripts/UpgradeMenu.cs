using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject openUpgradesButton;

    private void OnTriggerEnter(Collider other)
    {
        openUpgradesButton.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        openUpgradesButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        openUpgradesButton.SetActive(false);

        Time.timeScale = 0f;
    }
    public void CloseUpgradeMenu()
    {
        upgradeMenu.SetActive(false);

        Time.timeScale = 1f;
    }
}
