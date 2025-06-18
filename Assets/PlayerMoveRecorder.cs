using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecordedStep {
    public float time;
    public Vector3 position;
}

public class PlayerMoveRecorder : MonoBehaviour {
    public List<RecordedStep> recordedPath = new();

    void Update() {
        Vector2 vel = GetComponent<Rigidbody2D>().linearVelocity;
        if (ActionManager.Instance.isRecording&&vel != new Vector2(0,0))
        {
            recordedPath.Add(new RecordedStep
            {
                time = Time.time - GameTimer.Instance.startTime,
                position = transform.position
            });
        }
    }

    public List<RecordedStep> GetPathCopy() {
        return new List<RecordedStep>(recordedPath);
    }

    public void Clear() {
        recordedPath.Clear();
    }
}
