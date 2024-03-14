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
    private AudioClip gunshotSound;

    public void Shoot()
    {
        AudioManager.Singleton.PlaySoundEffect(this.gunshotSound);

        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        Vector3 dir = bullet.transform.rotation * this.defaultDir;
        Vector3 velocity = dir * this.bulletSpeed;
        bullet.SetVelocity(velocity);
        bullet.SetDamage(this.bulletDamage);
    }


}
