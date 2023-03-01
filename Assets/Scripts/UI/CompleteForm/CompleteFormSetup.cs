using Infrastructure;
using UnityEngine;
using Zenject;

public class CompleteFormSetup : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private UIRoot _uiRoot;
    [SerializeField] private CompleteForm _prefab;
    private DiContainer _diContainer;

    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void OnEnable()
    {
        _level.LevelComplete += Open;
    }

    private void OnDisable()
    {
        _level.LevelComplete -= Open;
    }

    private void Open()
    {
        _diContainer.InstantiatePrefab(_prefab, _uiRoot.transform);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

}
