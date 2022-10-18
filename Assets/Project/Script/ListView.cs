using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;

public class Task
{
    public int id;
    public string context;
}
public class ListView : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject prefab;
    public ReactiveCollection<Task> taskCollection = new ReactiveCollection<Task>();
    List<GameObject> cache = new List<GameObject>();
    private void Awake()
    {
        //リストビュー更新のコールバック
        taskCollection.ObserveAdd().Subscribe(x =>
        {
            ListUpdate();
        });
    }
    void ListUpdate()
    {
        //スクロールビューをクリア
        foreach (var item in cache)
        {
            Destroy(item);
        }

        //タスクパネルを生成
        foreach (var item in taskCollection)
        {
            var tmp = Instantiate(prefab, content.transform);
            cache.Add(tmp);
            var tmp2 = tmp.GetComponent<TaskText>();
            tmp.GetComponent<TaskDelete>().selfTaskID=item.id;
            tmp2.TextChange(item.context);
        }
    }
}
