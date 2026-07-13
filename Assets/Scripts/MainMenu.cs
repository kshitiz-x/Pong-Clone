using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject playButton;
    public GameObject quitButton;

    [Header("Difficulty Buttons")]
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject backButton;

    void Start()
    {
        ShowMainMenu();
    }

    // ==========================
    // MAIN MENU
    // ==========================

    void ShowMainMenu()
    {
        playButton.SetActive(true);
        quitButton.SetActive(true);

        easyButton.SetActive(false);
        mediumButton.SetActive(false);
        hardButton.SetActive(false);
        backButton.SetActive(false);
    }

    // ==========================
    // SHOW DIFFICULTY MENU
    // ==========================

    public void ShowDifficulty()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);

        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        hardButton.SetActive(true);
        backButton.SetActive(true);
    }

    // ==========================
    // BACK BUTTON
    // ==========================

    public void Back()
    {
        ShowMainMenu();
    }

    // ==========================
    // DIFFICULTY BUTTONS
    // ==========================

    public void Easy()
    {
        GameSettings.difficulty = Difficulty.Easy;
        SceneManager.LoadScene("Pong");
    }

    public void Medium()
    {
        GameSettings.difficulty = Difficulty.Medium;
        SceneManager.LoadScene("Pong");
    }

    public void Hard()
    {
        GameSettings.difficulty = Difficulty.Hard;
        SceneManager.LoadScene("Pong");
    }

    // ==========================
    // QUIT
    // ==========================

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}