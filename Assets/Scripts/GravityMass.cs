using UnityEngine;

namespace GravityLace
{
    public class GravityMass : MonoBehaviour
    {
        [SerializeField]
        private double CurrentMass = default;
        [SerializeField]
        private Vector3 CurrentVelocity = default;

        public double Mass => CurrentMass;

        //To do: add double precision
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }

        private void Awake()
        {
            Position = transform.position / (float)GravitySystem.ScaleFactor;
            Velocity = CurrentVelocity;
            GravitySystem.Register(this);
        }

        private void Update()
        {
            CurrentVelocity = Velocity;
            Velocity = CurrentVelocity;
            transform.position = Position * (float) GravitySystem.ScaleFactor;
        }

        private void OnDestroy()
        {
            GravitySystem.Unregister(this);
        }
    }
}
