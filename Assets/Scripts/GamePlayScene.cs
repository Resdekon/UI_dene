using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScene : MonoBehaviour
{
    public GameObject escPanel; // Inspector'da panel objesini buraya atay�n
    public Button resumeButton, optionsButton, exitButton; // Butonlar� Inspector'da atay�n
    private bool isGamePaused = false;

    private void Start()
    {
        escPanel.SetActive(false); // Ba�lang��ta paneli gizle
        resumeButton.onClick.AddListener(ResumeGame);
        optionsButton.onClick.AddListener(OpenOptionsScene);
        exitButton.onClick.AddListener(ExitToMainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        isGamePaused = !isGamePaused;
        escPanel.SetActive(isGamePaused);
        Time.timeScale = isGamePaused ? 0 : 1; // Oyunu durdur veya devam ettir
    }

    private void ResumeGame()
    {
        TogglePauseMenu();
    }

    private void OpenOptionsScene()
    {
        SceneManager.LoadScene("Options_Scene"); // Options sahnesinin ad�n� do�ru girin
    }

    private void ExitToMainMenu()
    {
        Time.timeScale = 1; // Oyunu devam ettir
        SceneManager.LoadScene("Main_Menu"); // Main Menu sahnesinin ad�n� do�ru girin
    }
}
