using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class DataManager : MonoBehaviour
{
    public GameObject[] toys;
    public static DataManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public Color toyColor;
        public int toyIndex;
        public bool hasToy;
        public string toyName;
    }

    public static void SaveGameData()
    {
        SaveData data = new SaveData();
        data.toyColor = ToyCreationManager.currentToyColor;
        data.toyIndex = ToyCreationManager.toyIndex;
        data.hasToy = ToyCreationManager.isCreated;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            ToyCreationManager.currentToyColor = data.toyColor;
            ToyCreationManager.isCreated = data.hasToy;
            ToyCreationManager.toyIndex = data.toyIndex;

        }
    }


    public void ExitGame()
    {
        //put save in here that should be saved when pressing quit
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
