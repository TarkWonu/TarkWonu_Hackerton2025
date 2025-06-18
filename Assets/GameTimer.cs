using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    public float startTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time;
    }

    public void RestartTimer()
    {
        startTime = Time.time;
    }
    public float ElapsedTime => Time.time - startTime;
}
