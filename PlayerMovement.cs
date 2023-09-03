using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    private PlayerCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<PlayerCollider>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !playerCollider.LeftHit())
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !playerCollider.RightHit())
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
    }
}
