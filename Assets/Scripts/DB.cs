using UnityEngine;
using System.Collections;
using Firebase.Database;
using UnityEngine.UI;
using Firebase.Auth;
using System;

public class DB : MonoBehaviour
{
    DatabaseReference dbreference;
    public Text textLogin;
    FirebaseAuth auth;
    public Text textInfo;
    public GameObject OkR, OkL;

    public InputField email, password1, password2, login, password;
    void Start()
    {
        dbreference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += Auth_State;
        Auth_State(this, null);
        auth.SignOut();
    }

    private void Auth_State(object sender, EventArgs e)
    {
        if(auth.CurrentUser != null)
        {
            OkL.SetActive(true);   
        }else{
            textLogin.text = "Пароль или эл.почта не верны";
        }
    }

    public void SaveData(string email, string password)
    {
        /*User_1 user = new User_1(str, 15);  // ���������� ���� �� �����
        string json = JsonUtility.ToJson(user);
        dbreference.Child("Users").Child(str).SetRawJsonValueAsync(json);
*/

        // ���������� �����-�� 1 ������
        //dbreference.Child("Users").Child("ID_Users").Child("email").SetValueAsync(email);
        //dbreference.Child("Users").Child("ID_Users").Child("password").SetValueAsync(password);
    }
    
    public IEnumerator LoadData(string str)
    {
        var user = dbreference.Child("Users").Child(str).GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if(user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if(user.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;

            Debug.Log(snapshot.Child("score").Value.ToString());

            //text.text = snapshot.Child("score").Value.ToString();
        }

    }
    public void ButtonLogin()
    {
        auth.SignInWithEmailAndPasswordAsync(login.text, password.text);
    }
    public void ButtonRegistration()
    {
        if(password1.text == password2.text)
        {
            auth.CreateUserWithEmailAndPasswordAsync(email.text, password1.text);
            OkR.SetActive(true);
        }
        else{
            textInfo.text = "Проверьте пароли";
        }
    }
    public void SaveResalt(string str)
    {
        dbreference.Child("Users").Child("ID_Users").Child("email").SetValueAsync(str);
        dbreference.Child("Users").Child("ID_Users").Child("record").SetValueAsync(0);
        //Users user = new Users(str, 15);  // ���������� ���� �� �����
        //string json = JsonUtility.ToJson(user);
        //dbreference.Child("Users").Child(str).SetRawJsonValueAsync(json);
    }
}
