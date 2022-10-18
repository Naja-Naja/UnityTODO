using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeleteButton : MonoBehaviour
{
    public List<int> deletelist = new List<int>();
    [SerializeField] Button button;
    void Start()
    {
        button.onClick.AddListener(delete);
    }
    void delete()
    {
        //TODOíœˆ—
    }
}
