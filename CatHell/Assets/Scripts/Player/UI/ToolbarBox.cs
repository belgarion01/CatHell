using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarBox : MonoBehaviour
{
    [SerializeField] private Image _toolImage;
    [SerializeField] private Image _backgroundImage;
    
    public void Init(Tool tool)
    {
        _toolImage.sprite = tool.Sprite;
    }
    
    public void SetSelected(bool selected)
    {
        _backgroundImage.color = selected ? Color.red : Color.white;
    }
}
