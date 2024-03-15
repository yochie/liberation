using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int maxAmmo;

    private int currentAmmo;

    private void Start()
    {
        this.currentAmmo = this.maxAmmo;
    }

    internal float GetCurrentAmmo()
    {
        return this.currentAmmo;
    }

    internal float GetMaxAmmo()
    {
        return this.maxAmmo;
    }

    internal void Consume()
    {
        if (currentAmmo <= 0)
            return;
        this.currentAmmo--;
    }

    internal void Replenish(int amount)
    {
        if (currentAmmo >= this.maxAmmo)
            return;
        this.currentAmmo = Math.Clamp(this.currentAmmo + amount, 0, this.maxAmmo);
    }
}