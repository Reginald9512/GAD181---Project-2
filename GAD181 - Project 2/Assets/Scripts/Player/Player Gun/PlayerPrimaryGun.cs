using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrimaryGun : MonoBehaviour
{
    public AudioClip reloadSound;
    public AudioClip gunFire;
    public AudioSource gunSounds;

    //Upgrade Buttons
    public GameObject reloadButton1;
    public GameObject reloadButton2;
    public GameObject reloadButton3;
    public GameObject damagebutton1;
    public GameObject damagebutton2;
    public GameObject damagebutton3;

    //weapon stats
    public int weaponDamage, magazineCapacity, bulletsPerPress;
    public float range, spread, reloadTime, timeBetweenShooting, timeBetweenBurst;
    public bool allowButtonHold;
    private int bulletsLeft, bulletsShot;
    
    //bools
    private bool shooting, readyToShoot, reloading;
    
    //references
    public Camera playerCamera;
    public Transform muzzlePoint;
    public RaycastHit rayHit;
    public LayerMask isEnemy;

    public TextMeshProUGUI ammunitionCounter;

    private void Awake()
    {
        bulletsLeft = magazineCapacity;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
        ammunitionCounter.SetText(bulletsLeft + " | " + magazineCapacity);
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetButtonDown("Fire1");
        }
        else
        {
            shooting = Input.GetButtonDown("Fire1");
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineCapacity && !reloading)
        {
            Reload();

            gunSounds.PlayOneShot(reloadSound);
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerPress;
            Shoot();

            gunSounds.PlayOneShot(gunFire);
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //raycast for bullet
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out rayHit, range, isEnemy))
        {
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyHealth>().enemyHealth -= weaponDamage;
        }

        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, muzzlePoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenBurst);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineCapacity;
        reloading = false;
    }


    //UPGRADE SYSTEM BELOW

    public void FasterReload1()
    {
        reloadTime = 2.0f;

        reloadButton1.SetActive(false);
        reloadButton2.SetActive(true);
    }
    public void FasterReload2()
    {
        reloadTime = 1.5f;

        reloadButton2.SetActive(false);
        reloadButton3.SetActive(true);
    }

    public void moreDamage1()
    {
        weaponDamage = 35;

        damagebutton1.SetActive(false);
        damagebutton2.SetActive(true);
    }
    public void moreDamage2()
    {
        weaponDamage = 50;

        damagebutton2.SetActive(false);
        damagebutton3.SetActive(true);
    }
}
