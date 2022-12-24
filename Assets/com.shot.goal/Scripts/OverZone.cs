using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<UIManager>().OpenWindow(5);
        UIManager.CheckResult(false);
    }
}
