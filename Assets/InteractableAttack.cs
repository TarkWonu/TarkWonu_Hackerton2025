using UnityEngine;

public class InteractableAttack : InteractableBase
{
    public override void DoAction(string interactableId)
    {
        Debug.Log("Attacked!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Interact();
        }
    }
}