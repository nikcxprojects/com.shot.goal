using UnityEngine;

public class Level : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(0, FindObjectOfType<UIManager>().topBorder.position.y - 1.95f);
    }
}
