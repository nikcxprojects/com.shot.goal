using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score ;

    private GameObject _last = null;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject options;
    [SerializeField] GameObject top;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject result;

    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;

    [Space(10)]
    public Transform topBorder;
    public Transform bottomBorder;

    private void Awake()
    {
        OpenWindow(0);
    }

    private void Start()
    {
        Block.OnCollisionEnter += () =>
        {
            scoreText.text = $"{++score}";
        };
    }

    private void Update()
    {
        int min = Mathf.FloorToInt(GameManager.Instance.ElapsedSeconds / 60);
        int sec = Mathf.FloorToInt(GameManager.Instance.ElapsedSeconds % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void OpenMenu()
    {
        OpenWindow(0);
        game.SetActive(false);

        GameManager.Instance.DestroyOld();
    }

    public void StartGameOnClick()
    {
        score = 0;

        scoreText.text = $"{score}";
        GameManager.Instance.StartGame();

        OpenWindow(3);
    }

    public void OpenWindow(int windowIndex)
    {
        if(_last && windowIndex != 4)
        {
            _last.SetActive(false);
        }

        switch(windowIndex)
        {
            case 0: _last = menu; break;
            case 1: _last = options; break;
            case 2: _last = top; break;
            case 3: _last = game; break;
            case 4: _last = pause;break;
            case 5: _last = result; break;
        }

        _last.SetActive(true);
        Time.timeScale = windowIndex == 4 ? 0 : 1;
    }
}