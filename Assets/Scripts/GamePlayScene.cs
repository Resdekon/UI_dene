using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScene : MonoBehaviour
{
    public GameObject escPanel; // Inspector'da panel objesini buraya atayýn
    public Button resumeButton, optionsButton, exitButton; // Butonlarý Inspector'da atayýn
    private bool isGamePaused = false;

    private void Start()
    {
        escPanel.SetActive(false); // Baþlangýçta paneli gizle
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
        SceneManager.LoadScene("Options_Scene"); // Options sahnesinin adýný doðru girin
    }

    private void ExitToMainMenu()
    {
        Time.timeScale = 1; // Oyunu devam ettir
        SceneManager.LoadScene("Main_Menu"); // Main Menu sahnesinin adýný doðru girin
    }
}
