using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCorrection : MonoBehaviour
{
    public LayerMask groundLayer;

    public float distanceToFeet = 0.5f;
    public float raycastDistance = 1;

    private PlayerCollider playerCollider;

    private Vector3 positionLastFrame;
    private bool groundedLastFrame;

    private void Start()
    {
        playerCollider = GetComponent<PlayerCollider>();
        groundedLastFrame = playerCollider.IsGrounded();
    }

    private void LateUpdate()
    {
        if (transform.position != positionLastFrame)
        {
            CorrectPosition();
        }
    }

    private void CorrectPosition()
    {
        Vector3 center = transform.position;
        Vector3 left = center - Vector3.right * (transform.localScale.x / 2.1f);
        Vector3 right = center + Vector3.right * (transform.localScale.x / 2.1f);

        RaycastHit2D centerHit = Physics2D.Raycast(center, Vector3.down, raycastDistance, groundLayer);
        RaycastHit2D leftHit = Physics2D.Raycast(left, Vector3.down, raycastDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right, Vector3.down, raycastDistance, groundLayer);

        float offsetY = 0;

        if (IsBelowGround(centerHit) || IsMovingDownSlope(centerHit))
        {
            offsetY = centerHit.distance - distanceToFeet;
        }

        if (IsBelowGround(leftHit) || IsMovingDownSlope(leftHit))
        {
            offsetY = Mathf.Min(offsetY, leftHit.distance - distanceToFeet);
        }

        if (IsBelowGround(rightHit) || IsMovingDownSlope(rightHit))
        {
            offsetY = Mathf.Min(offsetY, rightHit.distance - distanceToFeet);
        }

        transform.position -= Vector3.up * offsetY;
        positionLastFrame = transform.position;
        groundedLastFrame = playerCollider.IsGrounded();
    }

    private bool IsBelowGround(RaycastHit2D hit)
    {
        return hit.distance != 0 && hit.distance < distanceToFeet;
    }

    private bool IsMovingDownSlope(RaycastHit2D hit)
    {
        return groundedLastFrame && transform.position.y == positionLastFrame.y && hit.distance > distanceToFeet;
    }
}
