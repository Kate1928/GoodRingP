using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public InputField email, password1, password2;
    private DB db;

    void Start()
    {
        db = GetComponent<DB>();
    }


    public void Button()
    {
        if(password1.text == password2.text)
        {
            db.SaveData(email.text, password1.text);
        }
        
        //StartCoroutine(db.LoadData(Name.text));
    }
    
}
