using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        Destroy(gameObject, 4);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyPatrolling enemy = collision.GetComponent<EnemyPatrolling>();
        if(enemy != null)
        {
            enemy.TakeDamage(true);
        }
    }



}