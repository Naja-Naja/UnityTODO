using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class ListView : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject prefab;
    ReactiveCollection<string> collection = new ReactiveCollection<string>();
    private void Awake()
    {
        collection
         .ObserveAdd()
         .Subscribe(x =>
    {
        Debug.Log(string.Format("Add [{0}] = {1}", x.Index, x.Value));
        ListUpdate();
    });
    }

    private void Start()
    {
        collection.Add("aaa");
        collection.Add("bbb");
    }
    void ListUpdate()
    {
        foreach (var item in collection)
        {
            var tmp = Instantiate(prefab, content.transform);
            //tmp.GetComponent<>
        }
    }
}
