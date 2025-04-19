using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float ShootSpeed, shootTimer;
    private bool isShooting;

    public int maxAmmo = 35;
    private int currentAmmo;
    public float nachladeZeit = 1f;
    private bool ladetNach = false;

    [SerializeField] private AudioSource shootingSound;


    private void Start()
    {
        currentAmmo = maxAmmo;
        isShooting= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ladetNach)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && !isShooting)
        {
            currentAmmo--;
            StartCoroutine(Shoot());
            shakeubody.Instance.Shake(1f,.1f);  

        }
    }
    IEnumerator Reload()
    {
        ladetNach = true;
        yield return new WaitForSeconds(nachladeZeit);
        currentAmmo = maxAmmo;
        ladetNach=false;
    }


    IEnumerator Shoot()
    {
        isShooting = true;
        shootingSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        

        yield return new WaitForSeconds(shootTimer);




        isShooting=false;
    }
}
