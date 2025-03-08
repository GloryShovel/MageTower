using UnityEngine;

public class StatisticsController : MonoBehaviour
{
    public StatWriter writer;

    public void UpdateData(Stats stats)
    {
        writer.Write(stats);
    }
}
