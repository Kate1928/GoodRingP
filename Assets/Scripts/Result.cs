using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result : MonoBehaviour
{
    public int Res;
    public static int Record;
    public TextMeshProUGUI NowResult;
    public TextMeshProUGUI NowRecord;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Res = 0;
        Record = PlayerPrefs.GetInt("my_Record");
        NowResult.text = "Результат:" + Res;
        NowRecord.text = "Рекорд:" + Record;
        DontDestroyOnLoad(NowRecord);
        //NowRes = GetComponen<TextMesh>; 
    }

    // Update is called once per frame
    public void Update()
    {
        if (Player.transform.position.y > 0)
        {
            Res = (int)Player.transform.position.z;
            NowResult.text = "Результат:" + Res;
            if (Res > Record)
            {
                NowRecord.text = "Рекорд:" + Res;
                Record = Res;
                PlayerPrefs.SetInt("my_Record", Record);
                PlayerPrefs.Save();
            }
        }
    }
    
}
