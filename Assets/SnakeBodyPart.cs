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

    private Directions _direction;
    private Directions Direction
    {
        get => _direction;
        set
        {
            _direction = value;
            switch (_direction)
            {
                case (Directions.Up):
                    GetComponent<SpriteRenderer>().sprite = spBodyVertical;
                    break;
                case (Directions.Right):
                    GetComponent<SpriteRenderer>().sprite = spBodyHorizontal;
                    break;
                case (Directions.Down):
                    GetComponent<SpriteRenderer>().sprite = spBodyVertical;
                    break;
                case (Directions.Left):
                    GetComponent<SpriteRenderer>().sprite = spBodyHorizontal;
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
        Vector2 previousPosition = transform.position;

        transform.position = newPosition;
        Direction = newDirection;

        if (transform.childCount > 0)
        {
            var p = GetBodyPartPositionRelativeToParent(
                transform.position, previousPosition, previousDirection);
            transform.GetChild(0).GetComponent<SnakeBodyPart>().Move(p, previousDirection);
        }
    }

    // Called when Init()-ing
    public static Vector2 GetBodyPartPositionRelativeToParent(Vector2 position, Directions direction)
    {
        switch (direction)
        {
            case (Directions.Up):
                return new Vector2(position.x, position.y - 1);
            case (Directions.Right):
                return new Vector2(position.x - 1, position.y);
            case (Directions.Down):
                return new Vector2(position.x, position.y + 1);
            case (Directions.Left):
                return new Vector2(position.x + 1, position.y);
            default:
                return new Vector2(position.x - 1, position.y);
        }
    }

    // Called when Move()-ing
    public static Vector2 GetBodyPartPositionRelativeToParent(
        Vector2 position, Vector2 previousPosition, Directions direction)
    {
        switch (direction)
        {
            case (Directions.Up):
                if (position.y - 1 >= Config.GridSize.y)
                {
                    return new Vector2(position.x, position.y - 1);
                }
                else
                {
                    return new Vector2(position.x, previousPosition.y + 1);
                }
            case (Directions.Right):
                if (position.x - 1 >= Config.GridSize.x)
                {
                    return new Vector2(position.x - 1, position.y);
                }
                else
                {
                    return new Vector2(previousPosition.x + 1, position.y);
                }
            case (Directions.Down):
                if (position.y + 1 < Config.GridSize.height)
                {
                    return new Vector2(position.x, position.y + 1);
                }
                else
                {
                    return new Vector2(position.x, previousPosition.y - 1);
                }
            case (Directions.Left):
                if (position.x + 1 < Config.GridSize.width)
                {
                    return new Vector2(position.x + 1, position.y);
                }
                else
                {
                    return new Vector2(previousPosition.x - 1, position.y);
                }
            default:
                return new Vector2(position.x - 1, position.y);
        }
    }
}
