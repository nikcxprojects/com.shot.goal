using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform container;

    private void OnEnable() => UpdateBoard();

    public void UpdateBoard()
    {
        int[] scores = new int[container.childCount];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(4500, 9999);
        }

        int[] times = new int[container.childCount];
        for (int i = 0; i < times.Length; i++)
        {
            times[i] = Random.Range(150, 600);
        }

        var sortedScores = scores.OrderByDescending(i => i).ToArray();
        for(int i = 0; i < container.childCount; i++)
        {
            Text leader = container.GetChild(i).GetChild(1).GetComponentInChildren<Text>();
            leader.text = string.Format("{0:0000}", sortedScores[i]);
        }

        for (int i = 0; i < container.childCount; i++)
        {
            Text timeText = container.GetChild(i).GetChild(2).GetComponentInChildren<Text>();

            int min = Mathf.FloorToInt(times[i] / 60);
            int sec = Mathf.FloorToInt(times[i] % 60);

            timeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
    }
}
