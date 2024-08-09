using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [HideInInspector] public Color teamColor;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    // Update is called once per frame
    void Start()
    {

    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath);  
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.TeamColor;
        }  
    }
}


[Serializable]
class SaveData
{
    public Color TeamColor;
}


