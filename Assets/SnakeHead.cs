﻿using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    const int STEP_SIZE = 1;

    public Sprite spUp, spRight, spDown, spLeft;

    private Directions _direction;
    public Directions Direction
    {
        get => _direction;
        set
        {
            _direction = value;
            switch (_direction)
            {
                case (Directions.Up):
                    GetComponent<SpriteRenderer>().sprite = spUp;
                    break;
                case (Directions.Right):
                    GetComponent<SpriteRenderer>().sprite = spRight;
                    break;
                case (Directions.Down):
                    GetComponent<SpriteRenderer>().sprite = spDown;
                    break;
                case (Directions.Left):
                    GetComponent<SpriteRenderer>().sprite = spLeft;
                    break;
            }
        }
    }

    public void Move()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.StartsWith("Rabbit"))
        {
            SendMessageUpwards("AteRabbit");
        }
        if (other.gameObject.name.StartsWith("BodyPart"))
        {
            SendMessageUpwards("Died");
        }
    }
}
