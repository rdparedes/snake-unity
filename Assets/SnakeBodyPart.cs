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

    public Vector2 PreviousPosition { get; private set; }
    private GameObject _child;
    public GameObject Child
    {
        get => _child;
        set
        {
            _child = value;
            UpdateSprite();
        }
    }
    private Directions _direction;
    public Directions LastDirection { get; private set; }
    public Directions Direction
    {
        get => _direction;
        set
        {
            LastDirection = _direction;
            _direction = value;
            UpdateSprite();
        }
    }

    public void Init(Directions startingDirection, Vector2 startingPosition)
    {
        LastDirection = startingDirection;
        _direction = startingDirection;
        UpdateSprite();
        transform.position = startingPosition;
    }

    public void Move(Vector2 newPosition, Directions newDirection)
    {
        Directions previousDirection = Direction;
        PreviousPosition = transform.position;
        Direction = newDirection;
        transform.position = newPosition;
        if (Child)
        {
            Child.GetComponent<SnakeBodyPart>().Move(PreviousPosition, previousDirection);
        }
    }

    public void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = GetSpriteForDirection();
    }

    private Sprite GetSpriteForDirection()
    {
        switch (_direction)
        {
            case (Directions.Up):
                if (Child)
                {
                    if (LastDirection == Directions.Right)
                    {
                        return spCornerRightUp;

                    }
                    else if (LastDirection == Directions.Left)
                    {
                        return spCornerLeftUp;
                    }
                    else
                    {
                        return spBodyVertical;
                    }
                }
                else
                {
                    return spTailUp;
                }
            case (Directions.Right):
                if (Child)
                {
                    if (LastDirection == Directions.Up)
                    {
                        return spCornerLeftDown;

                    }
                    else if (LastDirection == Directions.Down)
                    {
                        return spCornerLeftUp;
                    }
                    else
                    {
                        return spBodyHorizontal;
                    }
                }
                else
                {
                    return spTailRight;
                }
            case (Directions.Down):
                if (Child)
                {
                    if (LastDirection == Directions.Left)
                    {
                        return spCornerLeftDown;

                    }
                    else if (LastDirection == Directions.Right)
                    {
                        return spCornerRightDown;
                    }
                    else
                    {
                        return spBodyVertical;
                    }
                }
                else
                {
                    return spTailDown;
                }
            case (Directions.Left):
                if (Child)
                {
                    if (LastDirection == Directions.Up)
                    {
                        return spCornerRightDown;

                    }
                    else if (LastDirection == Directions.Down)
                    {
                        return spCornerRightUp;
                    }
                    else
                    {
                        return spBodyHorizontal;
                    }
                }
                else
                {
                    return spTailLeft;
                }
            default:
                return spBodyHorizontal;
        }
    }
}
