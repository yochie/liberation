using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacker : MonoBehaviour
{
    [SerializeField]
    private float kbSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Mover disablesControlForMover;

    private Vector2 kbVelocity;
    private float remainingSeconds;
    

    private void Start()
    {
        this.remainingSeconds = 0;
        this.kbVelocity = Vector2.zero;
    }

    public void FixedUpdate()
    {
        if (this.remainingSeconds > 0 && this.kbVelocity != Vector2.zero)
        {
            this.rb.velocity = (Vector3) this.kbVelocity;
            this.remainingSeconds -= Time.fixedDeltaTime;
            if(remainingSeconds <= 0)
            {
                this.disablesControlForMover.SetControl(inControl: true);
            }
        }
    }
    internal void Trigger(Vector2 hitFromPos, float durationSeconds)
    {
        //Debug.Log("kb");
        //Debug.Log(hitFromPos);
        //Debug.Log(durationSeconds);
        this.disablesControlForMover.SetControl(inControl: false);
        this.kbVelocity = ((Vector2) this.transform.position - hitFromPos) * this.kbSpeed;
        this.remainingSeconds = durationSeconds;
    }
}
