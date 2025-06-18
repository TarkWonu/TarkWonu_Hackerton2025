using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]

public class GhostPlayer : MonoBehaviour {
    public List<RecordedStep> path;
    public List<TimedAction> actions;
    private string ghostId;

    void Awake() {
        
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    void Start()
    {
        Destroy(gameObject, LoopController.Instance.loopDuration);
    }

    public void Init(List<RecordedStep> movePath, List<TimedAction> timedActions)
    {
        path = movePath;
        actions = timedActions;
        ghostId = "Ghost_" + GetInstanceID();
        StartCoroutine(Replay());
    }

    IEnumerator Replay() {
        float startTime = Time.time;
        int actionIndex = 0;

        foreach (var step in path) {
            float targetTime = startTime + step.time;
            while (Time.time < targetTime) yield return null;

            transform.position = step.position;

            while (actionIndex < actions.Count && actions[actionIndex].time <= step.time) {
                Trigger(actions[actionIndex]);
                actionIndex++;
            }
        }
    }

    void Trigger(TimedAction act) {
        var obj = GameObject.Find(act.targetId);
        if (obj == null) return;

        var interactable = obj.GetComponent<InteractableBase>();
        if (interactable == null) return;

        switch (act.method) {
            case "Interact":
                interactable.DoAction(act.actorId);
                break;
            case "ExitInteract":
                interactable.DoExitAction(act.actorId);
                break;
        }
    }
}
