using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    public float speed;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    public int nbBullet;
    public int nbBulletCurrent;

    public void Fire()
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
