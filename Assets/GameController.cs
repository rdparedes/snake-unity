using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public Vector2 playerStartingPosition;
    public GameObject snake;
    public GameObject rabbit;

    private GameObject snakeInstance;

    void Start()
    {
        Config.Init();
    }

    public void StartGame()
    {
        menu.SetActive(false);
        snakeInstance = Instantiate(snake, playerStartingPosition, Quaternion.identity);
        snakeInstance.GetComponent<Snake>().onDeathCallback = GameOver;
        Instantiate(rabbit);
    }

    void ShowMenu()
    {
        menu.SetActive(true);
    }

    void GameOver()
    {
        Destroy(snakeInstance);
        Destroy(GameObject.FindGameObjectWithTag("Rabbit"));
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        ShowMenu();
    }
}
