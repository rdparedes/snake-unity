using UnityEngine;

public class SnakeBodyPart : MonoBehaviour
{
    public Sprite
        spBodyHorizontal,
        spBodyVertical,
        spTailUp,
        spTailRight,
        spTailDown,
        spTailLeft,
        spCornerLeftDown,
        spCornerLeftUp,
        spCornerRightDown,
        spCornerRightUp;

    private GameObject _child;
    public GameObject Child { set => _child = value; }
    private Directions _direction;
    private Directions Direction
    {
        get => _direction;
        set
        {
            var lastDirection = _direction;
            _direction = value;
            switch (_direction)
            {
                case (Directions.Up):
                    if (_child)
                    {
                        if (lastDirection == Directions.Right)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerRightUp;

                        }
                        else if (lastDirection == Directions.Left)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerLeftUp;
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().sprite = spBodyVertical;
                        }
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = spTailUp;
                    }
                    break;
                case (Directions.Right):
                    if (_child)
                    {
                        if (lastDirection == Directions.Up)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerLeftDown;

                        }
                        else if (lastDirection == Directions.Down)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerLeftUp;
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().sprite = spBodyHorizontal;
                        }
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = spTailRight;
                    }
                    break;
                case (Directions.Down):
                    if (_child)
                    {
                        if (lastDirection == Directions.Left)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerLeftDown;

                        }
                        else if (lastDirection == Directions.Right)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerRightDown;
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().sprite = spBodyVertical;
                        }
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = spTailDown;
                    }
                    break;
                case (Directions.Left):
                    if (_child)
                    {
                        if (lastDirection == Directions.Up)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerRightDown;

                        }
                        else if (lastDirection == Directions.Down)
                        {
                            GetComponent<SpriteRenderer>().sprite = spCornerRightUp;
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().sprite = spBodyHorizontal;
                        }
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = spTailLeft;
                    }
                    break;
            }
        }
    }

    public void Init(Directions startingDirection, Vector2 startingPosition)
    {
        Direction = startingDirection;
        transform.position = startingPosition;
    }

    public void Move(Vector2 newPosition, Directions newDirection)
    {
        Directions previousDirection = Direction;
        Direction = newDirection;
        Vector2 previousPosition = transform.position;
        transform.position = newPosition;
        if (_child)
        {
            _child.GetComponent<SnakeBodyPart>().Move(previousPosition, previousDirection);
        }
    }
}
