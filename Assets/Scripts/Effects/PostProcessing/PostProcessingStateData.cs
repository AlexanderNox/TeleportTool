using UnityEngine;

namespace Effects.PostProcessing
{
    [CreateAssetMenu(menuName = "Create PostProcessingStateData", fileName = "PostProcessingStateData", order = 0)]
    public class PostProcessingStateData : ScriptableObject
    {
        [field:SerializeField] public AnimationCurve AnimationCurve;
        [field:SerializeField] public float AnimationDuration;
    }
}