using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextQueryManager : MonoBehaviour
{
    public delegate void OnQueryCompleted(byte[] result);
    public event OnQueryCompleted QueryCompleted;

    public string endPoint;
    
   // public WavesJson wavesJson;
    public WaveSpawner wavesSpawners;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTextRoutine(endPoint));
    }

    IEnumerator GetTextRoutine(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.result);

        if (webRequest.result.Equals(UnityWebRequest.Result.Success))
        {
            Debug.Log(webRequest.downloadHandler.text);
            WavesJson data = JsonUtility.FromJson<WavesJson>(webRequest.downloadHandler.text);
            wavesSpawners.SetConfig(data);
            wavesSpawners.StartSpawning();
        }
        else
        {
            Debug.Log(webRequest.error);
        }
    }
}
