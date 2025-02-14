using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D),typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float airwalkSpeed = 2f;
    public float runSpeed = 7f;
    public float jumpImpulse = 10f;

    Vector2 moveInput;

    TouchingDirections touchingDirections;

    public float CurrentMoveSpeed { get 
        {
            if (IsMoving && !touchingDirections.IsOnWall)
            {
                if (touchingDirections.IsGrounded)
                {
                    if (IsRunning)
                    {
                        return runSpeed;
                    }
                    else
                    {
                        return walkSpeed;
                    }
                }
                else
                {
                    return airwalkSpeed;
                }
                
            }
            else
            {
                return 0;
            }
        } 
    }

    [SerializeField]
    private bool _isMoving = false;
    [SerializeField]
    private bool _isRunning = false;
 

    public bool IsMoving { get 
        {
            return _isMoving;
        } 
        private set 
        { 
            _isMoving = value;
            animator.SetBool("_isMoving", value);
        } 
    }

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool("_isRunning", value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight { get{ return _isFacingRight; } private set{
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1,1);
            }
            _isFacingRight = value;
        } }

    Rigidbody2D rb;
    Animator animator;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    // Start is called before the first frame update
    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        animator.SetFloat("yVelocity",rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput =context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;

        setFacingDirection(moveInput);
    }

    private void setFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    
    }
}
