using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private Player PlayerPrefab { get; set; }
    private Goal GoalPrefab { get; set; }
    private Level LevelPrefab { get; set; }
    private GameObject BallPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        GoalPrefab = Resources.Load<Goal>("goal");
        LevelPrefab = Resources.Load<Level>("level");
        BallPrefab = Resources.Load<GameObject>("bullet");

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

    public void StartGame()
    {
        Instantiate(PlayerPrefab, EnvironmentRef);
        Instantiate(GoalPrefab, EnvironmentRef);
        Instantiate(LevelPrefab, EnvironmentRef);
        Instantiate(BallPrefab, EnvironmentRef);
    }

    public void EndGame()
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

        uiManager.OpenWindow(5);
    }
}