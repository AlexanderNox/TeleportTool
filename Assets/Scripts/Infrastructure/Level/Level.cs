using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
   public class Level : MonoBehaviour
   {
      [SerializeField] private LevelEndTrigger _levelEndTrigger;
      private Player _player;
      private SceneLoader _sceneLoader;
      
      public Action LevelComplete;

      [Inject]
      private void Construct(SceneLoader sceneLoader, Player player)
      {
         _sceneLoader = sceneLoader;
         _player = player;
      }

      private void OnEnable()
      {
         _player.RestartRequest += Restart;
         _levelEndTrigger.Triggerred += Complete;
      }

      private void OnDisable()
      {
         _player.RestartRequest -= Restart;
         _levelEndTrigger.Triggerred -= Complete;
      }

      private void Complete()
      {
         LevelComplete?.Invoke();
         gameObject.SetActive(false);
      }

      private void Restart()
      {
         _sceneLoader.Load(SceneManager.GetActiveScene().name);
      }
   }
}