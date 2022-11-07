using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] int score = 150;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float explosionDuration = 1f;
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
            OnDeath();
        }
    }

    private void OnDeath()
    {
        AddScore();
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }

    private void AddScore()
    {
        FindObjectOfType<GameSession>().AddScore(score);
    }
}
