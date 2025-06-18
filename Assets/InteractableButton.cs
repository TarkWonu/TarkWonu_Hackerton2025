using UnityEngine;

public class InteractablePlate : InteractableBase
{
    public DoorController targetDoor;
    private int overlappingCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsActor(other)) return;

        if (overlappingCount == 0)
        {
            Interact("Actor");
        }
        overlappingCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!IsActor(other)) return;

        overlappingCount--;
        if (overlappingCount <= 0)
        {
            overlappingCount = 0;
            ExitInteract("Actor");
        }
    }

    private bool IsActor(Collider2D col)
    {
        return col.CompareTag("Player") || col.CompareTag("Ghost");
    }

    public override void DoAction(string actorId)
    {
        targetDoor?.RegisterButton(interactableId, actorId);
    }

    public override void DoExitAction(string actorId)
    {
        targetDoor?.UnregisterButton(interactableId, actorId);
    }
    
    
}
