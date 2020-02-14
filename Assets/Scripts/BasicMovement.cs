﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    private float moveSpeed = 2f;
    private float walkSpeed = 2f;
    private float sneakSpeed = 0.75f;

    public bool faceRight = true;
    public bool isMoving = false;


    public SpriteRenderer sr;

    public void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    // Input
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = sneakSpeed;
            animator.SetBool("ShiftPressed", true);
        } else {
            moveSpeed = walkSpeed;
            animator.SetBool("ShiftPressed", false);
        }

        if (movement.x < 0) {
            sr.flipX = true;
        } else if (movement.x > 0) {
            sr.flipX = false;
        }
    }

    // Movement
    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
