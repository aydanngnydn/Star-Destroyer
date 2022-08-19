using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int enemyBulletDamage;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out Health playerHealth))
            {
                playerHealth.DecraseHealth(enemyBulletDamage);
                if (playerHealth.currentHealth <= 0)
                {
                    playerHealth.isAlive = false;
                }
            }
        }
        else
        {
            Debug.Log("There is no gameObject this" + name + "collides.");
        }
    }

    void Update()
    {

    }
}
