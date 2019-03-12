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
        if (_child)
        {
            _child.GetComponent<SnakeBodyPart>().Move(previousPosition, previousDirection);
        }
    }
}
