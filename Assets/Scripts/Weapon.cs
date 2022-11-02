using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private float projectileSpeed = 10f;

    private float lifeTime = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject lazer = Instantiate(
                lazerPrefab,
                transform.position,
                Quaternion.identity) as GameObject;

            lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            Destroy(lazer, lifeTime);
        }
    }
}
