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

        //Check if there is collision with enemy and if so destroy.
        EnemyPatrolling enemy = collision.GetComponent<EnemyPatrolling>();
        if(enemy != null)
        {
            Destroy(gameObject);
            enemy.sourceDie.Play();
            enemy.TakeDamage(true);
        }
    }



}
