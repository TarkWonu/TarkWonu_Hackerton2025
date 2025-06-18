using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

[SerializeField]
public class TimedAction {
    public float time;
    public string targetId;
    public string method;
    public string actorId;
}

public class ActionManager : MonoBehaviour {
    public static ActionManager Instance;
    public List<TimedAction> timeline = new();
    public bool isRecording = true;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Save(float time, string targetId, string method, string actorId) {
        if (!isRecording) return;
        timeline.Add(new TimedAction {
            time = time,
            targetId = targetId,
            method = method,
            actorId = actorId
        });
    }

    public void Clear() => timeline.Clear();
}
