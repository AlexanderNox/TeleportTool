using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
   public class Level : MonoBehaviour
   {
      [SerializeField] private EndTrigger _endTrigger;
      
      private const string MainMenuScene = "Main";
      private Player _player;
      private SceneLoader _sceneLoader;

      [Inject]
      private void Construct(SceneLoader sceneLoader, Player player)
      {
         _sceneLoader = sceneLoader;
         _player = player;
      }

      private void OnEnable()
      {
         _player.RestartRequest += Restart;
         _endTrigger.Triggerred += End;
      }

      private void OnDisable()
      {
         _player.RestartRequest -= Restart;
         _endTrigger.Triggerred -= End;
      }

      private void End()
      {
        
         _sceneLoader.Load(MainMenuScene);
      }

      private void Restart()
      {
         _sceneLoader.Load(SceneManager.GetActiveScene().name);
      }
   }
}