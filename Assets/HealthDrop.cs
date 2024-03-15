using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [SerializeField]
    private float healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        //other should be player since that is only layer that drops interact with
        Hitable playerHitable = other.GetComponent<Hitable>();
        playerHitable.Heal(this.healAmount);
        Destroy(this.gameObject);
    }
}
