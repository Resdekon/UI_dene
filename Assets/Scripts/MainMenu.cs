using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject exitConfirmationPanel;
    public Button exitButton;

    private void Start()
    {
        exitConfirmationPanel.SetActive(false);
        exitButton.onClick.AddListener(ShowExitConfirmation);
    }

    private void ShowExitConfirmation()
    {
        exitConfirmationPanel.SetActive(true);
    }

    public void OnYesButtonClick()
    {
        Application.Quit();
    }

    public void OnNoButtonClick()
    {
        exitConfirmationPanel.SetActive(false);
    }

    private void Update()
    {
        // ESC tuþuna basýldýðýnda ve panel açýksa paneli kapat
        if (Input.GetKeyDown(KeyCode.Escape) && exitConfirmationPanel.activeSelf)
        {
            exitConfirmationPanel.SetActive(false);
        }
    }
}
