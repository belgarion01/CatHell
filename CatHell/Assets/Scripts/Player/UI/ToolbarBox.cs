using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarBox : MonoBehaviour
{
    [SerializeField] private Image _toolImage;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _selectedBorder;
    [SerializeField] private TextMeshProUGUI _toolNameTextMesh;
    
    public void Init(Tool tool, int index)
    {
        _toolImage.sprite = tool.Sprite;
        _toolNameTextMesh.text = tool.Name;
        switch (index)
        {
            case 0:
                _backgroundImage.color = new Color(169f/255f, 209f/255f, 142f/255f);
                break;
            case 1:
                _backgroundImage.color = new Color(157f/255f, 195f/255f, 230f/255f);
                break;
            case 2 :
                _backgroundImage.color = new Color(244f/255f, 177f/255f, 131f/255f);
                break;
        }
    }
    
    public void SetSelected(bool selected)
    {
        _selectedBorder.gameObject.SetActive(selected);
        _toolNameTextMesh.gameObject.SetActive(selected);
    }
}
