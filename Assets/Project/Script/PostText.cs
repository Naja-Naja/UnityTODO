using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
class JsonObject
{
    public string message;
}

[System.Serializable]
public class PostText : MonoBehaviour
{
    [SerializeField] Button addTaskButton;
    [SerializeField] Text inputText;

    void Start()
    {
        addTaskButton.onClick.AddListener(PressButton);
    }

    IEnumerator Upload()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        JsonObject jsonObject = new JsonObject();
        jsonObject.message = inputText.text;
        string jsonText = JsonUtility.ToJson(jsonObject);
        Debug.Log(jsonText);

        var url = "http://localhost:3000/todo";

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonText);
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            // TODO: responseを通知する
            Debug.Log("Form upload complete!");
        }
    }
    void PressButton()
    {
        StartCoroutine(Upload());
    }
}