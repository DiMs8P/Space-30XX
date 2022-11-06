using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f;

    private void OnTriggerEnter2D(Collider2D collision){
        var damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer){
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
}
