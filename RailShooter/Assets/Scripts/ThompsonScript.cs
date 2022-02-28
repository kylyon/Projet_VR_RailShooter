using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThompsonScript : MonoBehaviour
{

    public float speed;
    public float WaitTime = 1.0f;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private float nextActionTime = 0.0f;
    private bool isFiring = false;
    
    public int nbBullet;
    public int nbBulletCurrent;

    public void StartFire()
    {
        isFiring = true;
    }

    public void EndFire()
    {
        isFiring = false;
    }

    private void Update()
    {
        if(Time.time > nextActionTime)
        {
            nextActionTime += WaitTime;
            if (isFiring)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        if (nbBulletCurrent > 0)
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnedBullet.AddComponent<Rigidbody>();
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            spawnedBullet.tag = "Bullet";
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 2);
            nbBulletCurrent--;
        }
    }
}
