using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskText : MonoBehaviour
{
    [SerializeField] Text text;
    public void TextChange(string content)
    {
        text.text = content;
    }
}
