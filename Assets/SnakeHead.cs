using UnityEngine;

public class SnakeHead : MonoBehaviour
{
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
}
