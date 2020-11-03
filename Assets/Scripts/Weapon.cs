using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range=100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shootDelay = 0.1f;
    bool canShoot = true;
    Text ammoText;
    private void Start()
    {
        ammoText = FindObjectOfType<AmmoDisplay>().GetComponent<Text>();
    }

    private void OnEnable()
    {
        canShoot = true;
    }
    private void Update()
    {
        DisplayAmmo();
        if (Input.GetButton("Fire1")&& canShoot)
        {   
            StartCoroutine(TryToShoot());
        }
    }

    private void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetAmmo(ammoType).ToString();
    }

    IEnumerator TryToShoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmo(ammoType) > 0)
            LaunchBullet();
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
        
    }

    private void LaunchBullet()
    {
        
        shootVFX.Play();
        ammoSlot.ReduceAmmo(ammoType);
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.TakeDamage(damage);
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var effect = Instantiate(hitVFX, hit.point, Quaternion.identity);
        Destroy(effect, 0.1f);
    }
}
