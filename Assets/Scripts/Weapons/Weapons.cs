using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots;
    [SerializeField] TextMeshProUGUI ammoText;


    bool canShoot = true;

    public AudioSource audioSource;



    private void OnEnable()
    {
        canShoot = true;

    }

    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            audioSource.Play();
            StartCoroutine(Shoot());
        }

    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            canShoot = false;
            PlayMuzzleFlash();
            ProcessRayCast();

            ammoSlot.ReduceAmount(ammoType);

        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }
    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();

    }
    void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

}
