// ────────────────────────────────
// LoopController.cs
// ────────────────────────────────
using UnityEngine;
using System.Collections.Generic;

public class LoopController : MonoBehaviour {
    public static LoopController Instance;
    public List<DoorController> doorsToReset;
    public GameObject ghostPrefab;
    public Transform spawnPoint;
    public PlayerMoveRecorder recorder;
    public GameObject player;
    public float loopDuration = 60f;

    private List<List<RecordedStep>> allPaths = new();
    private List<List<TimedAction>> allTimelines = new();

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        if (GameTimer.Instance.ElapsedTime >= loopDuration) {
            StartNewLoop();
        }
    }

    public void StartNewLoop() {
        
        allPaths.Add(recorder.GetPathCopy());
        allTimelines.Add(new List<TimedAction>(ActionManager.Instance.timeline));

        
        for (int i = 0; i < allPaths.Count; i++) {
            var ghost = Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity).GetComponent<GhostPlayer>();
            ghost.Init(allPaths[i], allTimelines[i]);
        }

        
        recorder.Clear();
        ActionManager.Instance.Clear();
        GameTimer.Instance.RestartTimer();
        ResetEnvironment();
    }

    private void ResetEnvironment() {
        foreach (var door in doorsToReset) door.ResetState();
        if (player != null) player.transform.position = spawnPoint.position;
    }
}
