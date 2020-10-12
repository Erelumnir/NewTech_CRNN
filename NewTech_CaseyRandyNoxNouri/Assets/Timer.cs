using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float startTime;
    public UnityEvent timeZero = new UnityEvent();

    public float currentTime { get; private set; }

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if(currentTime > 0)
        {
            currentTime = Mathf.Max(currentTime - Time.deltaTime, 0);
            if(currentTime == 0)
            {
                timeZero.Invoke();
            }
        }
    }

    public void ResetTimer()
    {
        currentTime = startTime;
    }
}
