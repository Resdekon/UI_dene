// NewGame.cs
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public InputField saveNameInput;

    public void CreateNewGame()
    {
        string saveName = saveNameInput.text;
        DataPersistenceManager.Instance.NewGame(saveName);
        SceneManager.LoadScene("GameplayScene");
    }
}
