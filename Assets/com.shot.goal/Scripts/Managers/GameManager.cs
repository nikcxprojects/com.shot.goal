using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private float nextFire;
    private const float fireRate = 0.15f;

    private Player PlayerPrefab { get; set; }
    private GameObject BulletPrefab { get; set; }
    private GameObject BlockPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        BulletPrefab = Resources.Load<GameObject>("bullet");
        BlockPrefab = Resources.Load<GameObject>("block");

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

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(BulletPrefab, EnvironmentRef);
        }
    }

    public void StartGame()
    {
        Instantiate(PlayerPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        Block[] blocks = FindObjectsOfType<Block>();
        foreach(Block b in blocks)
        {
            Destroy(b.gameObject);
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach(Bullet b in bullets)
        {
            Destroy(b.gameObject);
        }

        uiManager.OpenWindow(5);
    }
}