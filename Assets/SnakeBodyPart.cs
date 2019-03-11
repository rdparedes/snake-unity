using System.Collections;
using System.Collections.Generic;
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

    public void Move(Vector3 newPosition, Directions newDirection)
    {
        Directions previousDirection = Direction;

        transform.position = newPosition;
        Direction = newDirection;

        if (transform.childCount > 0)
        {
            var p = SnakeBody.GetBodyPartPositionRelativeToParent(transform.position, previousDirection);
            transform.GetChild(0).GetComponent<SnakeBodyPart>().Move(p, previousDirection);
        }
    }
}
