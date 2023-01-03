using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDataPersistence
{

    [SerializeField] public int maxJumps = 1;
    private int _jumpsLeft;
    [SerializeField] public float speed, jumpSpeed;
    [SerializeField] private LayerMask ground;

    private PlayerActions playerActions;

    private Rigidbody2D rb;
    private Collider2D col;

    public Animator anim;

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
        _jumpsLeft = maxJumps;
    }

    public void LoadData(Gamedata data){
        maxJumps = data.Jumps;
    }

    public void SaveData(ref Gamedata data){
        data.Jumps = maxJumps;
        data.SceneName = SceneManager.GetActiveScene().name;
    }

    private void Jump()
    {
        if(IsGrounded() && rb.velocity.y <= 0){
            _jumpsLeft = maxJumps;
        }
        if(_jumpsLeft > 0){
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            _jumpsLeft -= 1;
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
        bool playerRunningAnimation = movementInput > 0 || movementInput < 0;
        anim.SetBool("Running", playerRunningAnimation);
        Flip();
        FlipBack();
    }

    void Flip()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    void FlipBack()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
