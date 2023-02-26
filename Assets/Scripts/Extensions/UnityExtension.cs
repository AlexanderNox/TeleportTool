using Logic;
using UnityEngine;

namespace Extentions
{
    public static class UnityExtension
    {
        public static void ApplyMetamorphos(this Transform transform,
            MetamorphosData metamorphosData)
        {
            transform.position = metamorphosData.Position;
            transform.rotation = metamorphosData.Rotation;
            transform.localScale = metamorphosData.LocalScale;
        }
        
        public static void ApplyMetamorphos(this Rigidbody rigidbody,
            MetamorphosData metamorphosData)
        {
            rigidbody.mass = metamorphosData.Mass;
            rigidbody.velocity = metamorphosData.Velocity;
        }
    }
}