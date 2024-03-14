using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{

    [SerializeField]
    private float maxHP;

    [SerializeField]
    private ScreenShaker screenShaker;

    [SerializeField]
    private bool shakeScreenWhenHit;

    [SerializeField]
    private float shakeDurationSeconds;

    [SerializeField]
    private float shakeAmplitude;

    [SerializeField]
    private float shakeFrequency;

    [SerializeField]
    private SpriteFlasher spriteFlasher;

    [SerializeField]
    private Knockbacker knockbacker;

    [SerializeField]
    private float kbDurationSeconds;

    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private PlayerController forPlayer;

    [SerializeField]
    private float EnemyDespawnDelay;

    [SerializeField]
    private int addsToScoreOnDeath;

    [SerializeField]
    private GameObject dropsOnDeath;

    [Range(0f, 1f)]
    [SerializeField]
    private float dropRate;

    private float currentHP;

    private bool active;

    private void Start()
    {
        this.currentHP = this.maxHP;
        this.active = true;
    }

    private void SetHP(float val)
    {
        this.currentHP = Mathf.Clamp(val, 0, this.maxHP);
    }

    public void TakeHit(float damage, Vector2 hitFromPos)
    {
        Debug.Log("takehit");

        if (!this.active)
            return;

        this.SetHP(this.currentHP - damage);

        if (this.spriteFlasher != null)
            this.spriteFlasher.Trigger();

        if (this.knockbacker != null)
            this.knockbacker.Trigger(hitFromPos, this.kbDurationSeconds);

        if(this.screenShaker != null)
            this.screenShaker.Trigger(this.shakeDurationSeconds, this.shakeAmplitude, this.shakeFrequency);

        if(this.currentHP <= 0)
        {
            this.Die();

        }
    }

    internal void Heal(float healAmount)
    {
        Debug.Log("healed");

        if (!this.active)
            return;

        this.SetHP(this.currentHP + healAmount);
    }

    private void Die()
    {
        this.active = false;
        if (this.addsToScoreOnDeath > 0)
        {
            GameController.Singleton.AddToScore(this.addsToScoreOnDeath);
        }

        if (this.dropsOnDeath != null)
        {
            if(UnityEngine.Random.Range(0, 100) < (int) (this.dropRate * 100))
            {
                Instantiate(this.dropsOnDeath, this.transform.position, Quaternion.identity);
            }
        }

        if (this.isPlayer && this.forPlayer != null)
        {
            this.forPlayer.Die();
        }
        else
        {
            this.StartCoroutine(DespawnCoroutine());
        }
    }

    private IEnumerator DespawnCoroutine()
    {
        Debug.Log("Enemy killed");        
        yield return new WaitForSeconds(this.EnemyDespawnDelay);

        //TODO: fade out before destruction
        Destroy(this.gameObject);        
    }

    internal float GetMaxHP()
    {
        return this.maxHP;
    }

    internal float GetCurrentHP()
    {
        return this.currentHP;
    }
}
