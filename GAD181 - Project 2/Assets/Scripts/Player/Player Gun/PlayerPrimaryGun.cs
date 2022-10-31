using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrimaryGun : MonoBehaviour
{
    public AudioClip reloadSound;
    public AudioClip gunFire;
    public AudioSource gunSounds;

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

    //graphics
    public TextMeshProUGUI ammunitionCounter;
    public AudioSource GunSFX;
    //public GameObject muzzleFlash, bulletHoleGraphic;

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

        //shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerPress;
            Shoot();

            gunSounds.PlayOneShot(gunFire);

            GunShotSFX();
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

    private void GunShotSFX()
    {
        GunSFX.Play();
    }
}
