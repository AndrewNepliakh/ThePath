using UnityEngine;

public class ChooseActionWindowButtonsContainer : MonoBehaviour
{
    [field: SerializeField] public ActionButtonContainerType Type { get; set; }
    public ChooseActionWindowButtonsContainer Value => this;

    public void SetActive(bool state)
    {
       gameObject.SetActive(state);
    }
}