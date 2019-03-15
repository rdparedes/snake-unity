using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector2 playerStartingPosition;
    public GameObject snake;
    public GameObject rabbit;

    private GameObject snakeInstance;

    void Start()
    {
        Config.Init();
        BeginScene();
    }

    void BeginScene()
    {
        snakeInstance = Instantiate(snake, playerStartingPosition, Quaternion.identity);
        snakeInstance.GetComponent<Snake>().onDeathCallback = GameOver;
        Instantiate(rabbit);
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
        BeginScene();
    }
}
