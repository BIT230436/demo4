using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;

    public GameObject bulletPrefabs;
    public float shootingInterval = 0.2f;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [Header("Weapon Power Settings")]
    public int weaponPower = 1;
    public int maxweaponPower = 5;

    private float lastBulletTime;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime > shootingInterval)
            {
                Shoot();
                lastBulletTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        // Simple logic for weapon power: could fire multiple bullets or just faster
        // Here we just fire one, but you can expand this based on weaponPower
        Instantiate(bulletPrefabs, transform.position + bulletOffset, Quaternion.identity);
    }
}
