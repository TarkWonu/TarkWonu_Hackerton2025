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
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time; // 루프 시작 시간 기록
    }

    public void RestartTimer()
    {
        startTime = Time.time; // 루프 재시작 시 호출
    }
    public float ElapsedTime => Time.time - startTime;
}