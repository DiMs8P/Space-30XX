using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFirePeriod = 0.1f;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] [Range(0,1)] float shotSoundVolume = 0.3f;

    private Coroutine firingCoroutine;

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1")){
            StopCoroutine(firingCoroutine);
        }
    }

    void Update(){
        Fire();
    }

    IEnumerator FireContinuously(){

        while(true){
            GameObject lazer = Instantiate(
                lazerPrefab,
                transform.position,
                Quaternion.identity) as GameObject;

            lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shotSFX, Camera.main.transform.position, shotSoundVolume);

            yield return new WaitForSeconds(projectileFirePeriod);
        }
    }
}
