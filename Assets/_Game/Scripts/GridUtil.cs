using UnityEngine;

public class GridUtil
{
    public const float CellSize = 2f;

    public static Vector2Int WorldToCell(Vector3 world)
    {
        return new Vector2Int(
            Mathf.FloorToInt(world.x / CellSize),
            Mathf.FloorToInt(world.z / CellSize));
    }

    public static Vector3 CellToWorldCenter(Vector2Int cell)
    {
        return new Vector3(
            (cell.x + 0.5f) * CellSize,
            0f,
            (cell.y + 0.5f) * CellSize);
    }
}
