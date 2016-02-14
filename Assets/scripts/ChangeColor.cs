using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    /// <summary>
    /// The color that this will become when clicked.
    /// </summary>
    public Color m_color = Color.blue;

    /// <summary>
    /// Changes the color.
    /// </summary>
    private void OnClick()
    {
        // Changes the color to m_color;
        this.GetComponent<Renderer>().material.color = m_color;
    }
}