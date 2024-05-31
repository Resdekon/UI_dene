using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance { get; private set; } // Instance property'si

    [SerializeField] private string saveFolderName = "saves";

    private GameData gameData; // gameData deðiþkeni
    private string filePath; // filePath deðiþkeni

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Path.Combine(Application.persistentDataPath, saveFolderName); // filePath tanýmlandý
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        LoadGame(); // Oyun baþladýðýnda verileri yükle
    }

    public void NewGame(string saveName)
    {
        gameData = new GameData();
        filePath = Path.Combine(Application.persistentDataPath, saveFolderName, saveName + ".json");
    }

    public List<string> GetSavedGameNames()
    {
        List<string> saveNames = new List<string>();
        string[] files = Directory.GetFiles(filePath, "*.json");
        foreach (string file in files)
        {
            saveNames.Add(Path.GetFileNameWithoutExtension(file));
        }
        return saveNames;
    }

    public void LoadGame()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.Log("Save file not found, starting a new game.");
            NewGame("default"); // Varsayýlan olarak "default" adýyla yeni oyun baþlat
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, json);
    }

    public GameData GetGameData()
    {
        return gameData;
    }
    public void SetFilePath(string newFilePath)
    {
        filePath = newFilePath;
    }
}
