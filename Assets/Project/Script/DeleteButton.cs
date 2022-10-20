using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
class JsonObject2
{
    public string id;
}

[System.Serializable]
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
        if (deletelist.Count != 0)
        {
            //TODOçÌèú
            for (int i = 0; i < deletelist.Count; i++)
            {
                int id = deletelist[i];
                Debug.Log(id);
                // api delete
                // this.apiDelete(id);
                StartCoroutine("apiDelete", id);
            }
        }
    }

    // API?delete??????????
    IEnumerator apiDelete(int id)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        JsonObject2 jsonObject2 = new JsonObject2();
        jsonObject2.id = id.ToString();
        string jsonText = JsonUtility.ToJson(jsonObject2);
        Debug.Log(jsonText);

        var url = "http://e8fe-106-184-155-206.ngrok.io/todo/delete";

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonText);
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("ok");
        }
        else
        {
            Debug.Log("err");
        }
    }
}
