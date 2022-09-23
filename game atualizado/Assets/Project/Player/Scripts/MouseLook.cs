using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lanterninha
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private Transform body;

        public float MouseSensitivity 
        { 
            get => mouseSensitivity; 
            set => mouseSensitivity = value; 
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (PlayerHealth.isDead) return;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            body.Rotate(Vector3.up * mouseX);
        }
    }
}

