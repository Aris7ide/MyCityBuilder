using UnityEngine;
using UnityEngine.InputSystem;

public class MouseGridPicker : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask terrainMask;
    [SerializeField] private Transform highlight;
    
    public bool HasCell { get; private set; }
    public Vector2Int Cell { get; private set; }

    void Update()
    {
        HasCell = false;

        if (Mouse.current != null)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(mousePos);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 500f, terrainMask))
            {
                Cell = GridUtil.WorldToCell(hit.point);
                HasCell = true;
            }
        }
        
        highlight.gameObject.SetActive(HasCell);
        if (HasCell)
        {
            highlight.position = GridUtil.CellToWorldCenter(Cell) + Vector3.up * 0.02f;
        }
    }

    void OnGUI()
    {
        string text = HasCell ? $"Cell: {Cell.x}, {Cell.y}" : "Cell: None";
        GUI.Label(new Rect(10, 10, 300, 25), text);
    }
}