using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private Animator gunAnimator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private BulletShooter shooter;

    private float facingDir;

    private Vector3 movement;

    private void Start()
    {
        this.facingDir = -1;
    }

    private void FixedUpdate()
    {
        this.transform.position += movement * this.speed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        Vector3 newMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        this.animator.SetBool("running", this.movement.magnitude > 0);
        float movingInDir;
        if (newMovement.x == 0)
            movingInDir = 0;
        else
            movingInDir = newMovement.x > 0 ? 1 : -1;
        this.FaceDir(movingInDir);

        this.movement = newMovement;

        bool shooting = Input.GetMouseButtonDown(0);
        if (shooting)
        {
            this.gunAnimator.SetTrigger("shoot");
            this.shooter.Shoot();
        }
    }

    private void FaceDir(float dir)
    {
        if (dir == 0)
            return;

        if (this.facingDir != dir)
            this.spriteRenderer.flipX = !this.spriteRenderer.flipX;
        this.facingDir = dir;

    }
}
