using UnityEngine;

public class Config : MonoBehaviour
{
    // All objects have 0,5 offset with respect to the Grid
    const float GRID_OFFSET = .5f;
    public static Rect GridSize { get; private set; }

    void Start()
    {
        GridSize = new Rect(
            GRID_OFFSET,
            GRID_OFFSET,
            (Screen.width / 16) + GRID_OFFSET,
            (Screen.height / 16) + GRID_OFFSET);

    }
}
