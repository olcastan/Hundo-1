﻿using UnityEngine;

[RequireComponent (typeof(Movement))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class PlayerController : MonoBehaviour
{

	public Camera cam;
	public Item FireSlot;
	private Animator anim;
	private Rigidbody2D rb;
	private Movement movementType;
	private Vector2 movementInput;
	private Vector2 mouseVec;
	private float mouseAngle;
	private bool isFiring;

	private void Awake() {
		movementType = GetComponent<Movement>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void Update() {
		movementInput.x = Input.GetAxisRaw("Horizontal");
		movementInput.y = Input.GetAxisRaw("Vertical");
		isFiring = Input.GetButton("Fire1");
	}

	private void FixedUpdate() {
		movementType.Move(rb, movementInput);
	
		if (isFiring && FireSlot != null) {
			FireSlot.TryUse();
		}

		UpdateAnimations();
	}

	private void UpdateAnimations() {
		mouseVec = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
		mouseAngle = Mathf.Atan2(mouseVec.y, mouseVec.x) * Mathf.Rad2Deg;

		if (movementInput != Vector2.zero) { // Is player moving?
			anim.StopPlayback();
		} else {
			anim.StartPlayback();
		}

		if (mouseAngle <= 33.0f && mouseAngle >= -33.0f) { // Right
			setAnimInput(1, 0);
		} else if (mouseAngle <= 66.0f && mouseAngle > 33.0f) { // Up right
			setAnimInput(1, 1);
		} else if (mouseAngle <= 123.0f && mouseAngle > 66.0f) { // Up
			setAnimInput(0, 1);
		} else if (mouseAngle <= 156.0f && mouseAngle > 123.0f) { // Up left
			setAnimInput(-1, 1);
		} else if (mouseAngle >= Mathf.PI || mouseAngle < -156.0f) { // Left
			setAnimInput(-1, 0);
		} else if (mouseAngle >= -156.0f && mouseAngle < -123.0f) { // Down left
			setAnimInput(-1, -1);
		} else if (mouseAngle >= -123.0f && mouseAngle < -66.0f) { // Down
			setAnimInput(0, -1);
		} else if (mouseAngle >= -66.0f && mouseAngle < -33.0f) { // Down right
			setAnimInput(1, -1);
		}
	}

    private void setAnimInput(float x, float y)
    {
        anim.SetFloat("xInput", x);
        anim.SetFloat("yInput", y);
    }
}
