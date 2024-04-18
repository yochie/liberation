using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private float bulletDamage;

    [SerializeField]
    private Vector3 defaultDir;

    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private AudioClip gunshotSound;

    [SerializeField]
    private Ammo ammo;

    [SerializeField]
    private Animator animator;

    public void Shoot()
    {
        if (this.ammo.GetCurrentAmmo() <= 0)
            return;
        else
        {
            this.ammo.Consume();
        }

        Bullet bullet = Instantiate(this.bulletPrefab, this.bulletSpawnPoint.position, this.transform.rotation);
        Vector3 dir = bullet.transform.rotation * this.defaultDir;
        Vector3 velocity = dir * this.bulletSpeed;
        bullet.SetVelocity(velocity);
        bullet.SetDamage(this.bulletDamage);

        if (AudioManager.Singleton != null)
            AudioManager.Singleton.PlaySoundEffect(this.gunshotSound);

        this.animator.SetTrigger("shoot");
    }
}
