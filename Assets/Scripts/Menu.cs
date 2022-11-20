using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [System.Serializable]
    public class MenuLogin
    {
        public TextMeshProUGUI login, password;
    }
    [System.Serializable]
    public class MenuRegistration
    {
        public TextMeshProUGUI login, password1, password2;
    }

    public MenuLogin loginWindow;
    public MenuRegistration registrationWindow;
    
    [SerializeField] private WebManager webManager;

    public void Login()
    {
        webManager.Login(loginWindow.login.text, loginWindow.password.text);
    }
    
    public void Register()
    {
        
        webManager.Registration(registrationWindow.login.text, registrationWindow.password1.text, registrationWindow.password2.text);
    }
}