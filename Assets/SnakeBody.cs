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
            var bodyPartPosition = SnakeBodyPart.GetBodyPartPositionRelativeToParent(
                parent.position, direction);
            newBodyPart.GetComponent<SnakeBodyPart>().Init(direction, bodyPartPosition);
            InstantiateBodyParts(
                index + 1,
                length,
                newBodyPart.transform,
                direction);
        }
    }

    public void Move(Vector2 newPosition, Vector2 previousPosition, Directions newDirection)
    {
        var p = SnakeBodyPart.GetBodyPartPositionRelativeToParent(newPosition, previousPosition, newDirection);
        transform.GetChild(0).GetComponent<SnakeBodyPart>().Move(p, newDirection);
    }
}
