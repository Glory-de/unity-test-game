using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private LayerMask ground;

    private PlayerActions playerActions;

    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();   
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();

    }

    // Start is called before the first frame update
    void Start()
    {
        playerActions.Land.Jump.performed += _ => Jump();
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y -= col.bounds.extents.y; 

        Vector2 bottomRightPoint= transform.position;
        bottomRightPoint.x -= col.bounds.extents.x;  
        bottomRightPoint.y -= col.bounds.extents.y;  

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }


    // Update is called once per frame
    void Update()
    {
        float movementInput = playerActions.Land.Move.ReadValue<float>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
