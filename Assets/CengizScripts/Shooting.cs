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




    private void Start()
    {
        isShooting= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !isShooting)
        {
            
            StartCoroutine(Shoot());
            shakeubody.Instance.Shake(1f,.1f);  

        }
    }



    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        

        yield return new WaitForSeconds(shootTimer);




        isShooting=false;
    }
}
