using UnityEngine.UI;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] Image img;

    [Space(10)]
    [SerializeField] Sprite winSprite;
    [SerializeField] Sprite loseSprite;

    private void Awake()
    {
        UIManager.OnGameEnd += (IsWin) =>
        {
            img.sprite = IsWin ? winSprite : loseSprite;
            img.SetNativeSize();
        };

        Destroy(gameObject, 2.0f);
    }
}
