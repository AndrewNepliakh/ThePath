using System;
using UnityEngine;
using UnityEngine.UI;


public class ChooseCoverButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private RectTransform _rectTransform;
    public Action<Vector3> OnButtonClicked;
    private Camera _camera;
    private Cover _cover;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClickedAdd);
    }

    public void SetPosition(Cover cover)
    {
        _cover = cover;
        _rectTransform.anchoredPosition = _camera.WorldToScreenPoint(cover.transform.position);
    }

    private void OnButtonClickedAdd()
    {
        OnButtonClicked?.Invoke(_cover.GetProperPosition());
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClickedAdd);
    }

    
}