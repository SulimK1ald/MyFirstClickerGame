using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuHelper : MonoBehaviour
{
    public Text MonstersText;
    public Text MonstersRecord;

    void Start()
    {
        loadRecord();
        MonstersRecord.text = SettingClass.MonstersRecord.ToString();
    }
    public void saveRecord()
    {
        PlayerPrefs.SetInt("MonstersRecord", SettingClass.MonstersRecord);
        PlayerPrefs.Save();
    }
    public void loadRecord()
    {
        SettingClass.MonstersRecord = PlayerPrefs.GetInt("MonstersRecord");
    }
    public void RestartClick()
    {
        SceneManager.LoadScene(0);
    }
    public void EndGame(int monstersCount)
    {
        if (SettingClass.MonstersRecord < monstersCount)
        {
            SettingClass.MonstersRecord = monstersCount;
            saveRecord();
        }
        MonstersText.text = "Убито монстров: " + monstersCount.ToString();
        MonstersRecord.text = SettingClass.MonstersRecord.ToString();
    }
}
