using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 200;
    GameObject deadMenu;
    private void Start()
    {
        if (FindObjectOfType<DeadMenu>())
        {
            deadMenu = FindObjectOfType<DeadMenu>().gameObject;
            deadMenu.SetActive(false);
        }
    }
    public void TakeDamage(float damage)
    {
        GetComponent<DisplayDamage>().ShowDamageImpact();
        health -= damage;
        if (health<=0)
        {
            HandleDeath();
        }

    }

    private void HandleDeath()
    {
        deadMenu.SetActive(true);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false; 
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
