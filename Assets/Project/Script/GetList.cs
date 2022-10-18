using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.Json;
public class GetList : MonoBehaviour
{
    [SerializeField] ListView listView;
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://raw.githubusercontent.com/OHMORIYUSUKE/animeapp-db/api/2022-4.json");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var animeList = JsonSerializer.Deserialize<Anime[]>(www.downloadHandler.text);

            for (int i = 0; i < animeList.Length; i++)
            {
                //animeDBのidとtitleをlistviewに登録する
                Debug.Log(animeList[i].title);
                listView.taskCollection.Add(new Task { id = i, context = animeList[i].title });
            }

            //  または、結果をバイナリデータとして取得します
            byte[] results = www.downloadHandler.data;
        }
    }
}
