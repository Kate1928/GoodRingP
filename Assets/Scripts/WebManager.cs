using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class UserData
{
    public Player playerData;
    public Error error;
}
[System.Serializable]
public class Error
{
    public string errorText;
    public bool isError;
}
[System.Serializable]
public class Player
{
    public string name;
    public Player(string name)
    {
        this.name = name;
    }
    public void SetName(string name) => this.name = name;
}

public class WebManager : MonoBehaviour
{
    [SerializeField] private string targetURL;
    
    //[SerializeField] private UnityEvent OnLogged, OnRegistered, OnError;    
    public UserData userData = new UserData();
    public enum RequestType
    {
        logging, register
    }
    public string getUserData(UserData userdata)
    {
        return JsonUtility.ToJson(userData);
    }
    public UserData setUserData(string data)
    {
        return JsonUtility.FromJson<UserData>(data);
    }

    private void Start()
    {
        userData.error = new Error() {errorText = "text", isError = true};
        userData.playerData = new Player("Kate");
    }
    public void Login(string login, string password)
    {
        StopAllCoroutines();
        Logging(login, password);
    }
    public void Registration(string login, string password1, string password2)
    {
        StopAllCoroutines();
        Registering(login, password1, password2);
    }
     public void Logging(string login, string password)
    {
        WWWForm form = new WWWForm();
        //form.AddField("type", RequestType.logging.ToString());
        form.AddField("login", login);
        form.AddField("password", password);
        StartCoroutine(SendData(form));
    }
    public void Registering(string login, string password1, string password2)
    {
        WWWForm form = new WWWForm();
        //form.AddField("type", RequestType.register.ToString());
        form.AddField("login", login);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        StartCoroutine(SendData(form));
    }
    IEnumerator SendData(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(targetURL, form))
        {
            yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    print(www.downloadHandler.text);
                    userData = setUserData(www.downloadHandler.text);
                }
        }
    }
}
