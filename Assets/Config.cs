using UnityEngine;

public class Config : MonoBehaviour
{
    // All objects have 0,5 offset with respect to the Grid
    const float GRID_OFFSET = .5f;
    const float SCENE_SIZE = 10;
    public static Rect GridSize { get; private set; }

    public static void Init()
    {
        GridSize = new Rect(
            GRID_OFFSET,
            GRID_OFFSET,
            SCENE_SIZE + GRID_OFFSET,
            SCENE_SIZE + GRID_OFFSET);
    }
}
