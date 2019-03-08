using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public GameObject bodyPart;

    private int _length;

    public void Init(Vector2 startingPosition, Directions startingDirection, int length)
    {
        _length = length;
        for (int i = 0; i < length; i++)
        {
            GameObject newBodyPart = Instantiate(bodyPart, transform);
            newBodyPart.transform.position = GetBodyPartStartingPosition(
                startingPosition, startingDirection, i);
            //bodyParts.Add(new SnakeBodyPart(snakeBodySprite)
            //{
            //    Position = new Vector2(startingPosition.X - 16 * i, startingPosition.Y),
            //    CurrentTile = HeadDirection,
            //    PreviousDirection = HeadDirection
            //});
            //if (i > 0)
            //{
            //    bodyParts[i].Next = bodyParts[i - 1];
            //}
        }
    }

    public void Move(Vector3 newPosition, Directions newDirection)
    {
        transform.position = newPosition;
    }

    Vector2 GetBodyPartStartingPosition(Vector2 position, Directions direction, int i)
    {
        switch (direction)
        {
            case (Directions.Up):
                return new Vector2(position.x, position.y - i);
            case (Directions.Right):
                return new Vector2(position.x - i, position.y);
            case (Directions.Down):
                return new Vector2(position.x, position.y + i);
            case (Directions.Left):
                return new Vector2(position.x + i, position.y);
            default:
                return new Vector2(position.x - i, position.y);
        }
    }

}
