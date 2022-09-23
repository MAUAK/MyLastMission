using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lanterninha
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 12f;
        [SerializeField] private float sprintSpeed = 12f;
        [SerializeField] private float crouchSpeed = 12f;
        [SerializeField] private float gravity = -9.81f;

        private CharacterController characterController;

        private Vector3 velocity;
        private Transform myTransform;
        private float speed;
        private float NormalHeight;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            myTransform = transform;
            speed = moveSpeed;
            NormalHeight = characterController.height;
        }

        private void Update()
        {
            if (PlayerHealth.isDead) return;

            HandleSpeed();
            Move();
        }

        private void HandleSpeed()
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
                characterController.height = NormalHeight;
            }
            else if(Input.GetKey(KeyCode.LeftControl))
            {
                speed = crouchSpeed;
                characterController.height = NormalHeight / 2;
            }
            else
            {
                speed = moveSpeed;
                characterController.height = NormalHeight;
            }
        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = myTransform.right * x + myTransform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}


