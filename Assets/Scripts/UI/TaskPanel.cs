using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{

    public void InputFieldChangeText(string text)
    {
        
    }
    public void OnButtonClick(Button button)
    {
        button.interactable = false;
        button.image.color = Color.green;
    }
}
