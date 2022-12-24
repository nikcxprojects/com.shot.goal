using UnityEngine;

public class Goal : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(0, FindObjectOfType<UIManager>().topBorder.position.y - 0.9f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("ball"))
        {
            return;
        }

        UIManager.CheckResult(true);
    }

    private void OnDestroy()
    {
        UIManager.OnGameEnd = null;
    }
}
