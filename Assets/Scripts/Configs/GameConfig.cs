using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public string StartScene {get; private set;}
    }
}