using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ExtraAssets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform player;
        [SerializeField] private float speed;
        [SerializeField] private float smoothTime = 0.2f;

        private Vector3 currentVelocity;
        private Vector3 smoothVelocity;
        private void LateUpdate()
        {
            Vector3 targetVelocity = (player.position + offset) - transform.position;
            currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref smoothVelocity, smoothTime);
            transform.Translate(currentVelocity * speed * Time.deltaTime, Space.World);
        }
    }
}