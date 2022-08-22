using System;
using UnityEngine;
using UnityEngine.UI;


public class ChooseCoverButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private RectTransform _rectTransform;
    private Action<Vector3> _onButtonClicked;
    private Camera _camera;
    private Vector3 _coverPosition;

    private void Awake()
    {
        _camera = Camera.main;
        _button.onClick.AddListener(OnButtonClicked);
    }

    public void SetPosition(Transform cover)
    {
        _coverPosition = cover.position;
        Debug.Log("Camera WorldToScreenPoint: " + _camera.WorldToScreenPoint(_coverPosition));
        Debug.Log("_rectTransform.anchoredPosition: " + _rectTransform.anchoredPosition);
        _rectTransform.anchoredPosition = _camera.WorldToScreenPoint(_coverPosition);
        Debug.Log("_rectTransform.anchoredPosition: " + _rectTransform.anchoredPosition);
    }

    private void OnButtonClicked()
    {
        _onButtonClicked?.Invoke(_coverPosition);
    }

    public void OnButtonClicked(Action<Vector3> setUnitAtCover)
    {
        _onButtonClicked = setUnitAtCover;
    }
}