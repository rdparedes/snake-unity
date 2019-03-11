using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    // Prefab to be instantiated for each part of the body
    public GameObject bodyPart;

    private int _length;

    public void Init(Directions direction, int length)
    {
        _length = length;
        InstantiateBodyParts(0, length, transform, direction);
    }

    private void InstantiateBodyParts(int index, int length, Transform parent, Directions direction)
    {
        if (index < length)
        {
            GameObject newBodyPart = Instantiate(bodyPart, parent);
            var bodyPartPosition = GetBodyPartPositionRelativeToParent(parent.position, direction);
            newBodyPart.GetComponent<SnakeBodyPart>().Init(direction, bodyPartPosition);
            InstantiateBodyParts(
                index + 1,
                length,
                newBodyPart.transform,
                direction);
        }
    }

    public void Move(Vector3 newPosition, Directions newDirection)
    {
        var p = GetBodyPartPositionRelativeToParent(newPosition, newDirection);
        transform.GetChild(0).GetComponent<SnakeBodyPart>().Move(p, newDirection);
    }

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

}
