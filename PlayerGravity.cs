using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float jumpPower;

    private float yMovement;
    private float gravity;

    private PlayerCollider playerCollider;

    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        yMovement = 0;
        gravity = 0.982f;

        playerCollider = GetComponent<PlayerCollider>();

        isJumping = false;
    }

    void FixedUpdate()
    {
        if (!playerCollider.IsGrounded())
        {
            yMovement -= gravity * Time.fixedDeltaTime;
        } else if (yMovement < 0)
        {
            yMovement = 0;
        }

        if (isJumping && yMovement <= 0)
        {
            isJumping = false;
        }

        if (yMovement > 0 && playerCollider.HeadHit())
        {
            yMovement = 0;
        }

        if (yMovement != 0)
        {
            transform.position = transform.position + Vector3.up * yMovement;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && playerCollider.IsGrounded())
        {
            yMovement = jumpPower;
            isJumping = true;
        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}
