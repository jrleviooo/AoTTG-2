﻿using UnityEngine;

namespace Assets.Scripts.Room.Minimap
{
    public class MinimapCamera : MonoBehaviour
    {
        public int Height = 500;
        public bool Rotate = true;
        [SerializeField] private IN_GAME_MAIN_CAMERA mainCamera;
        [SerializeField] private GameObject playerTransform;
        [SerializeField] private Camera minimapCamera;

        private void OnEnable()
        {
            mainCamera = FindObjectOfType<IN_GAME_MAIN_CAMERA>();
            if (mainCamera != null)
                playerTransform = mainCamera.main_object;
            minimapCamera = GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            if (mainCamera == null)
            {
                mainCamera = FindObjectOfType<IN_GAME_MAIN_CAMERA>();
                return;
            }
            else if (playerTransform == null)
            {
                playerTransform = mainCamera.main_object;
                return;
            }
            else if (minimapCamera == null)
            {
                minimapCamera = GetComponent<Camera>();
                return;
            }

            var pos = playerTransform.transform.position;
            var rot = mainCamera.transform.rotation;
            minimapCamera.orthographicSize = Height;
            transform.position = new Vector3(pos.x, 250, pos.z);
            transform.eulerAngles = Rotate
                ? new Vector3(90, rot.eulerAngles.y)
                : new Vector3(90, 0);
            //transform.rotation = Rotate
            //    ? new Quaternion(90f, mainCameraRotation.y, transform.rotation.z, transform.rotation.w)
            //    : new Quaternion(90f, 0f, transform.rotation.z, transform.rotation.w);
        }
    }
}
