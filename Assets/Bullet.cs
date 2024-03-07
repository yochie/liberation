using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float durationSeconds;

    private Vector3 velocity;

    private float ellapsedSeconds;

    private float damage;

    private void Start()
    {
        this.ellapsedSeconds = 0;
    }

    void FixedUpdate()
    {
        this.transform.position += this.velocity * Time.fixedDeltaTime;
        this.ellapsedSeconds += Time.fixedDeltaTime;
        if (ellapsedSeconds > durationSeconds)
            Destroy(this.gameObject);
    }

    public void SetVelocity(Vector3 v)
    {
        this.velocity = v;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy hit");
        Vector2 hitPos = other.ClosestPoint(this.transform.position);
        var hitable = other.GetComponent<Hitable>();
        if (hitable != null)
            hitable.TakeHit(this.damage, hitPos);
        //Destroy(other.gameObject);
    }
}
