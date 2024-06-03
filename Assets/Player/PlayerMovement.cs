using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float playerSpeed = 2.0f;
    public float sprintMult = 2.5f;
    float finalSpeed = 5.0f;
    public float characterID = 0;
    float charCool = 0;
    Vector2 movement;
    Vector2 direction;

    public Animator animator;
    void Start ()
    {
    }

    void Update ()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0) {
            direction.x = movement.x;
            direction.y = movement.y;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); //Performance trick
        animator.SetFloat("CharacterID", characterID);
        animator.SetFloat("IHor", direction.x);
        animator.SetFloat("IVert", direction.y);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) {
            finalSpeed = playerSpeed*sprintMult;
        }
        else {
            finalSpeed = playerSpeed;
        }
        rb.MovePosition(rb.position + movement * finalSpeed * Time.fixedDeltaTime);

        //Player Swapping
        if (Input.GetKey(KeyCode.F1)&&charCool<0.1) {characterID++;Debug.Log(characterID);charCool=30;}
        if (Input.GetKey(KeyCode.F2)&&charCool<0.1) {characterID--;Debug.Log(characterID);charCool=30;}
        if (charCool>0) charCool--;
    }
}

