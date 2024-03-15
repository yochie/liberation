using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    [SerializeField]
    private int ammoAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //other should be player since that is only layer that drops interact with
        Ammo playerAmmo = other.GetComponentInChildren<Ammo>();
        if (playerAmmo == null)
            return;
        playerAmmo.Replenish(this.ammoAmount);
        Destroy(this.gameObject);
    }
}
