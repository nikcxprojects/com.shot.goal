using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;
    public static Vector2 Velocity { get; private set; }


    private void Awake()
    {
        _camera = Camera.main;
        transform.position = new Vector2(0, FindObjectOfType<UIManager>().bottomBorder.position.y + 1.35f);
    }

    private void OnMouseDrag()
    {
        if (Time.timeScale < 1)
        {
            return;
        }

        transform.position = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }

    private void Update()
    {
        if(Time.timeScale < 1)
        {
            return;
        }

        Vector2 toInput = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        toInput.Normalize();

        toInput.x = Mathf.Clamp(toInput.x, -1, 1);
        toInput.y = Mathf.Clamp(toInput.y, 0.2f, 1);

        Velocity = toInput;
    }
}
