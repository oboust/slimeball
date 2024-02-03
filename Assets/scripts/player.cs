using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D RB;
    public float moveSpeed = 1f;

    public float collisonOffset = .01f;
    public ContactFilter2D movementFilter;
    private List<RaycastHit2D> castCollisons = new List<RaycastHit2D> ();

    public Animator animator;
    public bool Dead;
    hungerbar hungerscript;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hungerscript = FindObjectOfType<hungerbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() 
    {
        hungerscript.hungervalue = 1f;

        if(moveInput != Vector2.zero)
        {
            bool success = movePlayer(moveInput);
            if(!success)
            {
                success = movePlayer(new Vector2(moveInput.x, 0));
                if (!success)
                {
                    success = movePlayer(new Vector2(0, moveInput.y));
                }
            }
            animator.SetBool("IsWalking", success);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    void OnMove(InputValue value)
    {
        if (!Dead)
        {
            //hungerscript.losehunger(5f);
            moveInput = value.Get<Vector2>();
            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("XInput", moveInput.x);
                animator.SetFloat("YInput", moveInput.y);
            }
        }
    }
    public bool movePlayer(Vector2 Direction)
    {
        int count = RB.Cast(
            Direction,
            movementFilter,
            castCollisons,
            moveSpeed * Time.fixedDeltaTime + collisonOffset
            );
        if ( count == 0 ) 
        {
            Vector2 moveVector = Direction * moveSpeed * Time.fixedDeltaTime;
            RB.MovePosition(RB.position + moveVector);
            return true;
        }
        else
        {
            foreach(RaycastHit2D Hit in castCollisons)
            {
                print(Hit.ToString());
            }
            return false;
        }
    }
    private void OnInteract(InputValue value)
    {

    }
    public void hungerReplenish(float consume)
    {
        hungerscript.gainhunger(consume);
    }
    public void Die()
    {
        animator.SetBool("IsDead", true);
        Dead = true;
    }
}