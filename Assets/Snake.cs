using System;
using UnityEngine;

public enum Directions { Up, Right, Down, Left }

public class Snake : MonoBehaviour
{
    public float speed = 2f;
    public Action onDeathCallback;

    const int STARTING_LENGTH = 2;
    const float WAIT_TIME = 2f;

    //private readonly Config config;
    private SnakeHead _head;
    private SnakeBody _body;
    private float _updateTimer = 0f;

    private Directions _direction;
    private Directions _nextDirection;
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
        _nextDirection = Direction;
        _head = GetComponentInChildren<SnakeHead>();
        _body = GetComponentInChildren<SnakeBody>();
        _body.Init(Direction, STARTING_LENGTH);

    }

    void Update()
    {
        _updateTimer += Time.deltaTime * speed;

        HandleInput();

        if (_updateTimer >= WAIT_TIME)
        {
            var previousPosition = _head.transform.position;
            Direction = _nextDirection;
            _head.Move();
            _body.Move(previousPosition, Direction);
            _updateTimer -= WAIT_TIME;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Direction != Directions.Down)
        {
            _nextDirection = Directions.Up;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Direction != Directions.Left)
        {
            _nextDirection = Directions.Right;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Direction != Directions.Up)
        {
            _nextDirection = Directions.Down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction != Directions.Right)
        {
            _nextDirection = Directions.Left;
        }
    }

    void AteRabbit() => _body.Grow();

    void Died() => onDeathCallback();
}