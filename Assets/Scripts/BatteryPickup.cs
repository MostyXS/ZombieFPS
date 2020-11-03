using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChargeHim (other);
        }
    }

    private void ChargeHim(Collider other)
    {
        other.GetComponentInChildren<FlashlightSystem>().Charge();
        Destroy(gameObject);
    }
}
