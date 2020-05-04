/*
 * Created by: Hunter Duncan
 * Edits: Hunter Duncan
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [Tooltip("GameObject to shoot")]
    public GameObject projectile;
    [Tooltip("GameObject where projectile will spawn")]
    public GameObject projectileSpawnPoint;
    [Tooltip("Speed of projectile")]
    public float projectileSpeed = 15f;
    [Tooltip("How accurate the projectile is. Smaller number = more accurate, Larger number = less accurate")]
    public float accuracy = 15f;
    [Tooltip("Add the top most parent gameobject")]
    public GameObject character;

    public void Shoot()
    {
        float angle = Random.Range(-accuracy, accuracy);

        GameObject clone = Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);

        clone.transform.rotation = projectileSpawnPoint.transform.rotation;
        clone.transform.Rotate(0, angle, 0);

        if (clone == null)
        {
            return;
        }
        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * projectileSpeed, ForceMode.VelocityChange);
    }
}
