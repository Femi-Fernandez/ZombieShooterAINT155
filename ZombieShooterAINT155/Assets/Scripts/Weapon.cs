using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawnRight;
    public Transform bulletSpawnLeft;
    public float fireTime = 0.5f;

    public int bulletMagazine = 10;
    public float reloadTime = 0.0f;
    private bool emptyMagazine = false;

    private bool isFiring = false;
	// Use this for initialization
	private void SetFiring()
    {
        isFiring = false;
    }
	
    private void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);
        Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    private IEnumerator ReloadGun()
    {
            yield return new WaitForSeconds(1);   
            bulletMagazine = 10;
            reloadTime = 0.0f;
            emptyMagazine = false;      
    }
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0) && !emptyMagazine)
        {
            if (!isFiring)
            {
              Fire();
               bulletMagazine = bulletMagazine - 1;
                if(bulletMagazine == 0)
                {
                    emptyMagazine = true;
                    
                }
            }
        }


        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(ReloadGun());
        }

    }
}
