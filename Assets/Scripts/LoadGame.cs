using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadGame : MonoBehaviour
{
    public GameObject saveButtonPrefab; // Prefab'ý Inspector'da buraya atayýn
    public Transform contentTransform; // Content nesnesini Inspector'da buraya atayýn

    private void Start()
    {
        List<string> savedGameNames = DataPersistenceManager.Instance.GetSavedGameNames();

        foreach (string saveName in savedGameNames)
        {
            GameObject newButton = Instantiate(saveButtonPrefab, contentTransform);
            Button buttonComponent = newButton.GetComponent<Button>(); // Buton componentini al
            buttonComponent.GetComponentInChildren<Text>().text = saveName;
            buttonComponent.onClick.AddListener(() => LoadSelectedGame(saveName));
        }
    }

    public void LoadSelectedGame(string saveName)
    {
        DataPersistenceManager.Instance.SetFilePath(Path.Combine(Application.persistentDataPath, "saves", saveName + ".json"));
        DataPersistenceManager.Instance.LoadGame();
        SceneManager.LoadScene("GameplayScene"); // Oyun sahnesine geçiþ
    }

}
