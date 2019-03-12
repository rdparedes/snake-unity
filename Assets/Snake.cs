using UnityEngine;

public enum Directions { Up, Right, Down, Left }

public class Snake : MonoBehaviour
{
    public bool AteApple;
    public bool IsDead;
    public float speed = 2f;

    const int STARTING_LENGTH = 2;
    const float WAIT_TIME = 2f;

    //private readonly Config config;
    private SnakeHead _head;
    private SnakeBody _body;
    private float _updateTimer = 0f;

    private Directions _direction;
    private Directions Direction
    {
        get => _direction;
        set
        {
            _direction = value;
            GetComponentInChildren<SnakeHead>().Direction = value;
        }
    }

    void Start()
    {
        Direction = Directions.Right;
        _head = GetComponentInChildren<SnakeHead>();
        _body = GetComponentInChildren<SnakeBody>();
        _body.Init(Direction, STARTING_LENGTH);
    }

    void Update()
    {
        _updateTimer += Time.deltaTime * speed;

        _head.HandleInput();

        if (_updateTimer >= WAIT_TIME)
        {
            var previousPosition = _head.transform.position;
            _head.Move();
            _body.Move(_head.transform.position, previousPosition, Direction);
            _updateTimer -= WAIT_TIME;
        }
    }
}
