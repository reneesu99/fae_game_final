using UnityEngine.Networking;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using System.Text;
using System;

public class NetworkRequest

{
    [System.Serializable]
    public class Choice
    {
        public string text;

    }

    [System.Serializable]
    public class Response
    {
        public Choice[] choices;

    }
    
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
    public async Task<string> TestPost(string playerInput)
    {

        ChatGPTRequest body = new ChatGPTRequest();
        body.model = "text-davinci-003";
        body.prompt = @"
            You are a magical talking oracle cat named Pooky that lives 
            on a farm with a cat named Sooky(she/her pronouns) that buys 
            and sells goods and a chicken that was raised as a cat named 
            Mooky. There used to a farmer cat named Hooky but he recently
            left to farm oranges in Florida. You and the other animals are
            mad at him. I am a new farmer named Rooky who is replacing Hooky.
            I am currently tasked with farming 5 
            carrots. You are very enthusiastic and occasionally make cat 
            noises while talking. There is a big barn house that you and 
            the other cats lived in but the old farmer cat (Hooky) that 
            left took the keys so you cant get in. You are excited to meet me 
            and want to befriend me. You should be trying to respond in a way 
            that makes me feel closer to you. This is the conversation so far:";

        body.prompt += playerInput;
        body.prompt += ". Please write what the cat would respond:";
        body.max_tokens = 1000;

        var bodyJsonString = JsonUtility.ToJson(body);
        Debug.Log(bodyJsonString);
        var url = "https://api.openai.com/v1/completions";



        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        var key = Secrets.CHAT_GPT_KEY;
        request.SetRequestHeader("Authorization", "Bearer "+ key);


        var operation = request.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.Success)
        {
            var requestText = request.downloadHandler.text;

            Response response = JsonUtility.FromJson<Response>(requestText);
            // Debug.Log($"Success: {request.downloadHandler.text}");
            Debug.Log(response.choices[0].text);
            Debug.Log(request.downloadHandler.text);
            request.uploadHandler.Dispose();
            request.downloadHandler.Dispose();
            request.Dispose();
            return response.choices[0].text;
        }
        else
        {
            var errorText = request.downloadHandler.text;
            Debug.Log($"Failed: {request.downloadHandler.text}");
            request.uploadHandler.Dispose();
            request.downloadHandler.Dispose();
            request.Dispose();
            return $"Failed: {errorText}";
        }

    }
        

}
