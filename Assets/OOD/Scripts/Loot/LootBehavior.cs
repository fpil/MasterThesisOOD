using UnityEngine;

namespace Assets.OOD.Scripts.Loot
{
    public class LootBehavior : MonoBehaviour
    {
        public float rotationSpeed = 20f;
        public float elevationSpeed = 1f;
        public float elevationDistance = 0.5f;
        private float elevationOffset;

        void Start()
        {
            elevationOffset = transform.position.y;
        }

        void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            float elevation = elevationOffset + Mathf.Sin(Time.time * elevationSpeed) * elevationDistance;
            Vector3 newPosition = transform.position;
            newPosition.y = elevation;
            transform.position = newPosition;
        }
    }
}
