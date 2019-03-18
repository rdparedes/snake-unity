using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Button playButton, exitButton;
    public GameObject gameController;

    void Start()
    {
        Button btnPlayButton = playButton.GetComponent<Button>();
        Button btnExitButton = exitButton.GetComponent<Button>();

        btnPlayButton.onClick.AddListener(PlayButtonOnClick);
        btnExitButton.onClick.AddListener(ExitButtonOnClick);
    }

    void PlayButtonOnClick()
    {
        gameController.GetComponent<GameController>().StartGame();
    }

    void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
