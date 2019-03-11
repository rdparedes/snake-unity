using UnityEngine;

public enum Directions { Up, Right, Down, Left }

public class Snake : MonoBehaviour
{
    public bool AteApple;
    public bool IsDead;
    public float speed = 2f;

    const int STEP_SIZE = 1;
    const int STARTING_LENGTH = 2;
    const float WAIT_TIME = 2f;

    //private readonly Config config;
    private readonly SnakeHead _head;
    private readonly SnakeBody _body;
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

        GetComponentInChildren<SnakeBody>().Init(Direction, STARTING_LENGTH);
    }

    void Update()
    {
        _updateTimer += Time.deltaTime * speed;

        HandleInput();

        if (_updateTimer >= WAIT_TIME)
        {
            Move();
            _updateTimer -= WAIT_TIME;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Direction != Directions.Down)
        {
            Direction = Directions.Up;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Direction != Directions.Left)
        {
            Direction = Directions.Right;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Direction != Directions.Up)
        {
            Direction = Directions.Down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction != Directions.Right)
        {
            Direction = Directions.Left;
        }
    }

    void Move()
    {
        var previousPosition = transform.position;
        switch (Direction)
        {
            case (Directions.Up):
                transform.position = new Vector2(transform.position.x, transform.position.y + STEP_SIZE);
                break;
            case (Directions.Right):
                transform.position = new Vector2(transform.position.x + STEP_SIZE, transform.position.y);
                break;
            case (Directions.Down):
                transform.position = new Vector2(transform.position.x, transform.position.y - STEP_SIZE);
                break;
            case (Directions.Left):
                transform.position = new Vector2(transform.position.x - STEP_SIZE, transform.position.y);
                break;
        }
        CheckBounds();
        GetComponentInChildren<SnakeBody>().Move(transform.position, previousPosition, Direction);
    }

    void CheckBounds()
    {
        if (transform.position.x >= Config.GridSize.width)
        {
            transform.position = new Vector2(Config.GridSize.x, transform.position.y);
        }
        if (transform.position.y >= Config.GridSize.height)
        {
            transform.position = new Vector2(transform.position.x, Config.GridSize.y);
        }
        if (transform.position.x < Config.GridSize.x)
        {
            transform.position = new Vector2(Config.GridSize.width - 1, transform.position.y);
        }
        if (transform.position.y < Config.GridSize.y)
        {
            transform.position = new Vector2(transform.position.x, Config.GridSize.height - 1);
        }
    }
}
