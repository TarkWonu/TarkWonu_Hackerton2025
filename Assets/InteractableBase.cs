using UnityEngine;

public abstract class InteractableBase : MonoBehaviour {
    public string interactableId;

    public void Interact(string actorId = "Player") {
        DoAction(actorId);
        float time = Time.time - GameTimer.Instance.startTime;
        ActionManager.Instance.Save(time, interactableId, "Interact", actorId);
    }

    public void ExitInteract(string actorId = "Player") {
        DoExitAction(actorId);
        float time = Time.time - GameTimer.Instance.startTime;
        ActionManager.Instance.Save(time, interactableId, "ExitInteract", actorId);
    }

    public abstract void DoAction(string actorId);
    public virtual void DoExitAction(string actorId) { }
}