using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
	private bool moving = false;
	private bool running = false;
	private Vector2 movement;

	public float walkingSpeed;
	public float runningSpeed;

	private new Rigidbody2D rigidbody;

	// Start is called before the first frame update
	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (!moving) return;

		float speed = running ? runningSpeed : walkingSpeed;

		Vector2 position = rigidbody.position + (speed * Time.fixedDeltaTime * movement);

		rigidbody.MovePosition(position);
	}

	public void OnMovement(InputValue input) {
		movement = input.Get<Vector2>();
		moving = movement.x != 0 || movement.y != 0;
	}

	public void OnRun(InputValue input) {
		running = input.isPressed;
	}
}
