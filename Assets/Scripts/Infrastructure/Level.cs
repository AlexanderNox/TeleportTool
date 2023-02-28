using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
   public class Level : MonoBehaviour
   {
      [SerializeField] private EndTrigger _endTrigger;
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
         _endTrigger.Triggerred += Complete;
      }

      private void OnDisable()
      {
         _player.RestartRequest -= Restart;
         _endTrigger.Triggerred -= Complete;
      }

      private void Complete()
      { 
         LevelComplete?.Invoke();
      }

      private void Restart()
      {
         _sceneLoader.Load(SceneManager.GetActiveScene().name);
      }
   }
}