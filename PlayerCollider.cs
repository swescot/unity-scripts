using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public LayerMask groundLayer;

    private float raycastDistance = 0.05f;
    private bool isGrounded, headHit, leftHit, rightHit;

    void Update()
    {
        Vector3 bottomCenter = transform.position - Vector3.up * (transform.localScale.y / 2);
        Vector3 bottomLeft = bottomCenter - Vector3.right * (transform.localScale.x / 2.1f);
        Vector3 bottomRight = bottomCenter + Vector3.right * (transform.localScale.x / 2.1f);

        Vector3 topCenter = transform.position + Vector3.up * (transform.localScale.y / 2);
        Vector3 topLeft = topCenter - Vector3.right * (transform.localScale.x / 2.1f);
        Vector3 topRight = topCenter + Vector3.right * (transform.localScale.x / 2.1f);

        Vector3 leftCenter = transform.position - Vector3.right * (transform.localScale.y / 2);
        Vector3 rightCenter = transform.position + Vector3.right * (transform.localScale.y / 2);

        bool centerGrounded = Physics2D.Raycast(bottomCenter, Vector3.down, raycastDistance, groundLayer);
        bool leftGrounded = Physics2D.Raycast(bottomLeft, Vector3.down, raycastDistance, groundLayer);
        bool rightGrounded = Physics2D.Raycast(bottomRight, Vector3.down, raycastDistance, groundLayer);
        isGrounded = leftGrounded || centerGrounded || rightGrounded;

        bool centerHead = Physics2D.Raycast(topCenter, Vector3.up, raycastDistance, groundLayer);
        bool leftHead = Physics2D.Raycast(topLeft, Vector3.up, raycastDistance, groundLayer);
        bool rightHead = Physics2D.Raycast(topRight, Vector3.up, raycastDistance, groundLayer);
        headHit = centerHead || leftHead || rightHead;

        leftHit = Physics2D.Raycast(leftCenter, Vector3.left, raycastDistance, groundLayer);
        rightHit = Physics2D.Raycast(rightCenter, Vector3.right, raycastDistance, groundLayer);

        /*
        Debug.DrawRay(bottomCenter, Vector3.down * raycastDistance, centerGrounded ? Color.green : Color.red);
        Debug.DrawRay(bottomLeft, Vector3.down * raycastDistance, leftGrounded ? Color.green : Color.red);
        Debug.DrawRay(bottomRight, Vector3.down * raycastDistance, rightGrounded ? Color.green : Color.red);
        Debug.DrawRay(topCenter, Vector3.up * raycastDistance, centerHead ? Color.green : Color.red);
        Debug.DrawRay(topLeft, Vector3.up * raycastDistance, leftHead ? Color.green : Color.red);
        Debug.DrawRay(topRight, Vector3.up * raycastDistance, rightHead ? Color.green : Color.red);
        Debug.DrawRay(leftCenter, Vector3.left * raycastDistance, leftHit ? Color.green : Color.red);
        Debug.DrawRay(rightCenter, Vector3.right * raycastDistance, rightHit ? Color.green : Color.red);
        */
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool HeadHit()
    {
        return headHit;
    }

    public bool LeftHit()
    {
        return leftHit;
    }

    public bool RightHit()
    {
        return rightHit;
    }
}
