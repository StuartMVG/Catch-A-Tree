using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatchTree.Movement
{
    public class PaddleMovement : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 10f;
        Rigidbody2D paddleBody;
        Vector2 moveInput;
        // Start is called before the first frame update
        void Start()
        {
            paddleBody = GetComponent<Rigidbody2D>();
            EventHandler.CallUpdateScoreEvent(0);
        }

        private void FixedUpdate() 
        {
            PaddleMove(moveInput);    
        }

        public void Move(InputAction.CallbackContext value)
        {
            moveInput = value.ReadValue<Vector2>();
        }

        private void PaddleMove(Vector2 inputMovement)
        {
            Vector2 playerVelocity = new Vector2 (inputMovement.x * movementSpeed * Time.deltaTime, 0f);
            paddleBody.MovePosition(paddleBody.position + playerVelocity);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "tree")
            {
                EventHandler.CallUpdateScoreEvent(1);
                EventHandler.CallCaughtTreeEvent(other.gameObject);
            }
        }
    }
    
}

