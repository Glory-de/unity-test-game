using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
   [SerializeField] float moveSpeed = 1f;

    [Header("References")]
    public Rigidbody2D enemyRB;
    public BoxCollider2D enemyBoxCollider;

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight()){
            //MoveRight
            enemyRB.velocity = new Vector2(moveSpeed,0f);
        }else{
            //MoveLeft
            enemyRB.velocity = new Vector2(-moveSpeed,0f);
        }
    }

    private bool IsFacingRight(){
        return -transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collider){
        //Flip or Turn
        transform.localScale = new Vector2(Mathf.Sign(enemyRB.velocity.x), transform.localScale.y);
    }

    public void Die(){
        Destroy(gameObject);
    }

    public void TakeDamage(bool damage)
    {
        if (damage)
        {
            Die();  
        }
    }
}
