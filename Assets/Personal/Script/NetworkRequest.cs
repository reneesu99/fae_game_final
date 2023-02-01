using UnityEngine.Networking;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using System.Text;

public class NetworkRequest: MonoBehaviour

{
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        var url = "https://jsonplaceholder.typicode.com/todos/1";
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {www.error}");
        }

    }

    // void Start()
    // {
    //     StartCoroutine(Upload());
    // }

    [ContextMenu("Test Post")]

    public async void TestPost()
    {
        // var newForm = new Dictionary<string, string>();
        // newForm.Add("model", "text-davinci-003");
        ChatGPTRequest body = new ChatGPTRequest();
        body.model = "text-davinci-003";
        body.prompt = "You are my magical talking cat and I am a fairy. You are my companion. I say I feel alone.";
        // WWWForm form = new WWWForm();
        // form.AddField("model", "text-davinci-003");
        // form.AddField("prompt", "You are my magical talking cat and I am a fairy. You are my companion. I say I feel alone.");
        // Debug.Log(form);
        var bodyJsonString = JsonUtility.ToJson(body);
        Debug.Log(bodyJsonString);
        var url = "https://api.openai.com/v1/completions";
        // using var www = UnityWebRequest.Put(url, form);
        // // www.chunkedTransfer = false;
        // www.SetRequestHeader("Content-Type", "application/json");
        // www.SetRequestHeader("Authorization", "Bearer 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");
        // // UploadHandler customUploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(formData));
        // // customUploadHandler.contentType = "application/json";
        // // webRequest.uploadHandler = customUploadHandler;
        // www.SetRequestHeader("Accept", "application/json");
        // www.method = "POST";

        // www.SetRequestHeader("Host", "https://api.openai.com");
        // www.SetRequestHeader("Content-Length", "100");


        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer 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");


        var operation = request.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {request.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {request.downloadHandler.text}");
        }

    }
        
    // [ContextMenu("Test Upload")]
    // IEnumerator Upload()
    // {
    //     Debug.Log("posting");
    //     WWWForm form = new WWWForm();
    //     form.AddField("name", "test");
    //     form.AddField("salary", "123");
    //     form.AddField("age", "12");


    //     using (UnityWebRequest www = UnityWebRequest.Post("https://dummy.restapiexample.com/api/v1/create", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //             Debug.Log("Form upload complete!");
    //         }
    //     }
    // }
}
