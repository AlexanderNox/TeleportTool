//This class allows to have full control
//over the parameters transferred as a result of the metamorphosis.
using UnityEngine;

namespace Logic
{
    public struct MetamorphosData
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly Vector3 LocalScale;
        public readonly float Mass;
        public readonly Vector3 Velocity;
        public MetamorphosData(Transform transform, Rigidbody rigidbody)
        {
            Position = transform.position;
            Rotation = transform.rotation;
            LocalScale = transform.localScale;
            Mass = rigidbody.mass;
            Velocity = rigidbody.velocity;
        }
    }
}