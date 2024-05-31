using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public InputField nameInputField;
    public Button createButton;

    private void Start()
    {
        // Butona t�klama olay�n� dinle
        createButton.onClick.AddListener(CreateSave);
    }

    private void CreateSave()
    {
        // InputField'dan ismi al
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("�sim girmediniz!");
            return;
        }

        // Save i�lemini ger�ekle�tirin (�rne�in, PlayerPrefs kullanarak)
        SaveGame(playerName);

        Debug.Log("Save olu�turuldu: " + playerName);
    }

    private void SaveGame(string playerName)
    {
        // Save verisini olu�tur
        PlayerPrefs.SetString("saveName", playerName);
        PlayerPrefs.Save();

        // Alternatif olarak, dosya sistemi veya di�er save y�ntemlerini kullanabilirsiniz
        // �rnek olarak, bir dosya kaydetme:
        // System.IO.File.WriteAllText(Application.persistentDataPath + "/" + playerName + ".txt", "Save Data");
    }
}

