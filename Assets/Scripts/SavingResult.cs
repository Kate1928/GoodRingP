using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using Firebase;
//using Firebase.Database;
public class SavingResult : MonoBehaviour
{
    public GameObject LoginCanvas, RegistrationCanvas, StartCanvas, OkImage, HelpCanvas, Menu, Canvas;

    public void OkButton()
    {
        LoginCanvas.SetActive(false);
        RegistrationCanvas.SetActive(false);
        StartCanvas.SetActive(true);
    }
    public void HelpButton()
    {
        LoginCanvas.SetActive(false);
        RegistrationCanvas.SetActive(false);
        HelpCanvas.SetActive(true);
    }
    public void HelpButtonClose()
    {
        HelpCanvas.SetActive(false);
    }
    public void RegButton()
    {
        LoginCanvas.SetActive(false);
        StartCanvas.SetActive(false);
        RegistrationCanvas.SetActive(true);
        //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);
    }
    public void RegBut()
    {
        OkImage.SetActive(true);
        StartCanvas.SetActive(true);
        LoginCanvas.SetActive(false);
        RegistrationCanvas.SetActive(false);
        OkImage.SetActive(false);
    }
    
    public void LoginBut()
    {
        OkImage.SetActive(true);   
        StartCanvas.SetActive(true);
        LoginCanvas.SetActive(false);
        OkImage.SetActive(false);
    }

    public void SavingRes()
    {
        LoginCanvas.SetActive(true);
        StartCanvas.SetActive(false);
        //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);
    }
    public void StopButtton()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnStoppingButtton1()
    {
        Menu.SetActive(false);
    }
    public void UnStoppingButtton()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }
}
