using UnityEngine;

public class Rabbit : MonoBehaviour
{
    private void Start()
    {
        Vector2 newPosition;
        do
        {
            newPosition = generateRandomPosition();
        } while (Physics.CheckBox(newPosition, new Vector2(0.5f, 0.5f)) == true);
        transform.position = newPosition;
    }

    private Vector2 generateRandomPosition()
    {
        return new Vector2(
            Random.Range((int)Config.GridSize.x, (int)Config.GridSize.width),
            Random.Range((int)Config.GridSize.y, (int)Config.GridSize.height));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gameObject);
        Destroy(gameObject);
    }
}
