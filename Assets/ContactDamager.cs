using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    [SerializeField]
    private float damagePerTick;

    [SerializeField]
    private float framesPerTick;

    private int frameCount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.frameCount = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (frameCount++ % this.framesPerTick != 0)
        {
            return;
        }            

        var hitable = other.GetComponent<Hitable>();
        if (hitable == null)
            return;

        Vector2 hitPos = other.ClosestPoint(this.transform.position);
        hitable.TakeHit(this.damagePerTick, hitPos);
    }
}
