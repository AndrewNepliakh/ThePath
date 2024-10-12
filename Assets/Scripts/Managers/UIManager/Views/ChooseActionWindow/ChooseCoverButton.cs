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

    public void SetPosition(Cover cover, RectTransform parentRect)
    {
        _cover = cover;
        var yOffset = _cover.transform.localScale.y;
        var worldToScreenPoint = _camera.WorldToScreenPoint(cover.transform.position + Vector3.up * yOffset);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect, worldToScreenPoint, null, out var localPoint);
        _rectTransform.anchoredPosition = localPoint;
    }

    private void OnButtonClickedAdd()
    {
        gameObject.SetActive(false);
        OnButtonClicked?.Invoke(_cover.GetProperPosition());
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClickedAdd);
    }

    
}