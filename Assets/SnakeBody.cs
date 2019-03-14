using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    // Prefab to be instantiated for each part of the body
    public GameObject bodyPart;

    private bool _shouldGrow = false;
    private int _length;

    public void Init(Directions direction, int length)
    {
        _length = length;
        InstantiateBodyParts(0, length, direction);
    }

    public void Move(Vector2 previousPosition, Directions newDirection)
    {
        transform.GetChild(0).GetComponent<SnakeBodyPart>().Move(previousPosition, newDirection);
        if (_shouldGrow == true)
        {
            SnakeBodyPart tail = transform.GetChild(transform.childCount - 1).GetComponent<SnakeBodyPart>();
            GameObject newBodyPart = Instantiate(bodyPart, transform);
            tail.Child = newBodyPart;
            newBodyPart.GetComponent<SnakeBodyPart>().Init(tail.LastDirection, tail.PreviousPosition);
            _shouldGrow = false;
        }
    }

    public void Grow()
    {
        _shouldGrow = true;
    }

    private void InstantiateBodyParts(
        int index, int length, Directions direction, GameObject previousPartRef = null)
    {
        if (index < length)
        {
            GameObject newBodyPart = Instantiate(bodyPart, transform);
            var parentPosition = previousPartRef ? previousPartRef.transform.position : transform.position;
            var bodyPartPosition = GetBodyPartPositionRelativeToParent(parentPosition, direction);
            newBodyPart.GetComponent<SnakeBodyPart>().Init(direction, bodyPartPosition);
            if (previousPartRef)
            {
                previousPartRef.GetComponent<SnakeBodyPart>().Child = newBodyPart;
            }
            InstantiateBodyParts(
                index + 1,
                length,
                direction,
                newBodyPart);
        }
    }

    // Called when Init()-ing
    private Vector2 GetBodyPartPositionRelativeToParent(Vector2 parentPosition, Directions parentDirection)
    {
        switch (parentDirection)
        {
            case (Directions.Up):
                return new Vector2(parentPosition.x, parentPosition.y - 1);
            case (Directions.Right):
                return new Vector2(parentPosition.x - 1, parentPosition.y);
            case (Directions.Down):
                return new Vector2(parentPosition.x, parentPosition.y + 1);
            case (Directions.Left):
                return new Vector2(parentPosition.x + 1, parentPosition.y);
            default:
                return new Vector2(parentPosition.x - 1, parentPosition.y);
        }
    }
}
