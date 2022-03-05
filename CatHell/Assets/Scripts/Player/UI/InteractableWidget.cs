using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    public void UpdateUI(IInteractable interactable)
    {
        _textMesh.text = interactable.ActionName;
    }

    public void SetEnable(bool enable)
    {
        gameObject.SetActive(enable);
    }
}
