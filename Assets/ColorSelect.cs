using UnityEngine;
using UnityEngine.EventSystems;

public class ColorSelect : MonoBehaviour
{
    public void OnWatchColorSelect(Material material)
    {
        string _buttonName = EventSystem.current.currentSelectedGameObject.name;
        Color _color = SelectedColor(_buttonName);
        ChangeColorOfMaterial(_color, material);
    }

    Color SelectedColor(string _buttonName)
    {
        Color _color = new Color();

        if (_buttonName == "black button")
        {
            ColorUtility.TryParseHtmlString("#000000", out _color);
        }
        else if (_buttonName == "blue button")
        {
            ColorUtility.TryParseHtmlString("#284AA1", out _color);
        }
        else if (_buttonName == "red button")
        {
            ColorUtility.TryParseHtmlString("#740202", out _color);
        }
        else if (_buttonName == "white button")
        {
            ColorUtility.TryParseHtmlString("#A1A1A1", out _color);
        }
        return _color;

    }

    void ChangeColorOfMaterial(Color color, Material material)
    {
        material.color = color;
    }
}
