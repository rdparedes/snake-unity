using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject rabbit;

    void Start()
    {
        Config.Init();
        Instantiate(rabbit);
    }
}
