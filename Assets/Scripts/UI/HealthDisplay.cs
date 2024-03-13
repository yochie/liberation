using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField]
    private GameObject healthBar;

    internal void Set(float currentHP, float maxHP)
    {
        Vector3 newScale = this.healthBar.transform.localScale;
        newScale.x = currentHP / maxHP;
        this.healthBar.transform.localScale = newScale;
    }
}
