using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateMovement : MonoBehaviour
{
    public float normalMoveSpeed = 5f;
    public float boostMoveSpeed = 10f;
    public float dashCooldown = 3f; 
    public float minX = -5f;
    public float maxX = 5f;

    private CrateController crateController;
    private float dashTimer;
    private bool canDash = true;

    void Start()
    {
        crateController = GetComponent<CrateController>();
        dashTimer = dashCooldown;
    }

    void Update()
    {

        if (!canDash)
        {
            dashTimer -= Time.deltaTime;


            if (dashTimer <= 0f)
            {
                canDash = true;
                dashTimer = dashCooldown;
            }
        }


        float moveSpeed = canDash && Input.GetKey(KeyCode.LeftShift) ? boostMoveSpeed : normalMoveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;


        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            canDash = false;
        }
    }
}
