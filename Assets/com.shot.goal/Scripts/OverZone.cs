using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("ball"))
        {
            return;
        }

        FindObjectOfType<UIManager>().OpenWindow(5);
        UIManager.CheckResult(false);
    }

    private void OnDestroy()
    {
        UIManager.OnGameEnd = null;
    }
}
