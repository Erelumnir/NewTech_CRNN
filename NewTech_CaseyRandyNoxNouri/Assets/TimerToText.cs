using System;
using UnityEngine;

[ExecuteAlways]
public class TimerToText : MonoBehaviour
{
    public Timer timer;
    public TMPro.TextMeshPro textMesh;

    private void LateUpdate()
    {
        TimeSpan timeSpan = new TimeSpan((long)(timer.currentTime * TimeSpan.TicksPerSecond));
        textMesh.text = timeSpan.ToString(@"mm\:ss\:fff");
    }
}
