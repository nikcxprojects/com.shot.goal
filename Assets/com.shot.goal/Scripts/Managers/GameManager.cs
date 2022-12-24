using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private bool GameStarted { get; set; }


    private Player PlayerPrefab { get; set; }
    private Goal GoalPrefab { get; set; }
    private Level LevelPrefab { get; set; }
    private Ball BallPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    private const int initTime = 300;
    public float ElapsedSeconds { get; private set; }

    public UIManager uiManager;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        GoalPrefab = Resources.Load<Goal>("goal");
        LevelPrefab = Resources.Load<Level>("level");
        BallPrefab = Resources.Load<Ball>("ball");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Start()
    {
        Block.OnCollisionEnter += () =>
        {
            var hit = Instantiate(Resources.Load<AudioSource>("hit"));
            hit.mute = GameObject.Find("SFX Source").GetComponent<AudioSource>().mute;

            if(SettingsManager.VibraEnable)
            {
                Handheld.Vibrate();
            }
        };
    }

    private void Update()
    {
        if(Time.timeScale <= 0 || !GameStarted)
        {
            return;
        }

        ElapsedSeconds -= Time.deltaTime;
    }

    public void DestroyOld()
    {
        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        if (FindObjectOfType<Goal>())
        {
            Destroy(FindObjectOfType<Goal>().gameObject);
        }

        if (FindObjectOfType<Level>())
        {
            Destroy(FindObjectOfType<Level>().gameObject);
        }

        if (FindObjectOfType<Ball>())
        {
            Destroy(FindObjectOfType<Ball>().gameObject);
        }
    }

    public void StartGame()
    {
        ElapsedSeconds = initTime;

        DestroyOld();

        Instantiate(PlayerPrefab, EnvironmentRef);
        Instantiate(GoalPrefab, EnvironmentRef);
        Instantiate(LevelPrefab, EnvironmentRef);

        GameStarted = true;
    }

    public void ThrowBall()
    {
        if(FindObjectOfType<Ball>())
        {
            return;
        }

        Instantiate(BallPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        GameStarted = false;

        DestroyOld();

        uiManager.OpenWindow(5);
    }
}