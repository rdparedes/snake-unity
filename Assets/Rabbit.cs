using UnityEngine;

public class Rabbit : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(
            Random.Range((int)Config.GridSize.x, (int)Config.GridSize.width),
            Random.Range((int)Config.GridSize.y, (int)Config.GridSize.height));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gameObject);
        Destroy(gameObject);
    }
}
