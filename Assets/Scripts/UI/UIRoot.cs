using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class UIRoot : MonoBehaviour
{
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main; 
    }
}
