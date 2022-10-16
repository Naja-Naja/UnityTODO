using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] Button addTaskButton;
    [SerializeField] Text inputText;
    private void Start()
    {
        addTaskButton.onClick.AddListener(PressButton);
    }
    void PressButton()
    {
        //inputText.text
    }
}
