using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour
{
    [SerializeField] int ammoAmount;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GiveAmmo();
        }
    }

    private void GiveAmmo()
    {
        FindObjectOfType<Ammo>().AddAmmo(ammoAmount, ammoType);
        Destroy(gameObject);
    }
}
