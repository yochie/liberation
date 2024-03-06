using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float durationSeconds;

    private Vector3 velocity;

    private float ellapsedSeconds;

    private void Start()
    {
        this.ellapsedSeconds = 0;
    }

    void Update()
    {
        this.transform.position += this.velocity;
        this.ellapsedSeconds += Time.deltaTime;
        if (ellapsedSeconds > durationSeconds)
            Destroy(this.gameObject);
    }

    public void SetVelocity(Vector3 v)
    {
        this.velocity = v;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy hit");
        Destroy(collision.gameObject);
    }
}
