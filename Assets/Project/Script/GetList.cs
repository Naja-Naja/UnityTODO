using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using UnityEngine;
using UnityEngine.Networking;

class Todo
{
    public int id { get; set; }
    public string message { get; set; }
    public DateTime createAt { get; set; }
    public DateTime updateAt { get; set; }
}
public class GetList : MonoBehaviour
{
    [SerializeField] ListView listView;
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://e8fe-106-184-155-206.ngrok.io/todo");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var todoList = JsonSerializer.Deserialize<Todo[]>(www.downloadHandler.text);

            for (int i = 0; i < todoList.Length; i++)
            {
                //animeDBのidとtitleをlistviewに登録する
                Debug.Log(todoList[i].message);
                listView.taskCollection.Add(new Task { id = todoList[i].id, context = todoList[i].message });
            }

            //  または、結果をバイナリデータとして取得します
            byte[] results = www.downloadHandler.data;
        }
    }
}
