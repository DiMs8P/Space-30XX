using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private float _shotCounter = 0f;
    [SerializeField] float minTimeBetweenShots = 0.1f;
    [SerializeField] float maxTimeBetweenShots = 1f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] [Range(0,1)] float shotSoundVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        _shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot(){
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0f){
            Fire();
            _shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire(){
        GameObject lazer = Instantiate(
            projectile, 
            transform.position,
            Quaternion.identity
        ) as GameObject;

         lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
         AudioSource.PlayClipAtPoint(shotSFX, Camera.main.transform.position, shotSoundVolume);

    }
}
