using UnityEngine;

namespace GravityLace
{
    public class GravityMass : MonoBehaviour
    {
        [SerializeField] public double Mass = default;
        [SerializeField] public Vector3d Position = default;
        [SerializeField] public Vector3d Velocity = default;

        private void Awake()
        {
            Position = Space.GetSpacePosition(transform.position);
            GravitySystem.Register(this);
        }

        private void Update()
        {
            transform.position = Space.GetPositionFromSpace(Position);
        }

        private void OnDestroy()
        {
            GravitySystem.Unregister(this);
        }
    }
}
