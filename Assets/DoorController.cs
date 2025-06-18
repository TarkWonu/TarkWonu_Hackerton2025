using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DoorController : MonoBehaviour {
    public List<string> requiredButtons;
    private Dictionary<string, HashSet<string>> activePlateUsers = new();

    public void RegisterButton(string buttonId, string actorId) {
        if (!activePlateUsers.ContainsKey(buttonId))
            activePlateUsers[buttonId] = new HashSet<string>();

        activePlateUsers[buttonId].Add(actorId);
        CheckDoor();
    }

    public void UnregisterButton(string buttonId, string actorId) {
        if (activePlateUsers.ContainsKey(buttonId)) {
            activePlateUsers[buttonId].Remove(actorId);
            if (activePlateUsers[buttonId].Count == 0)
                activePlateUsers.Remove(buttonId);
        }
        CheckDoor();
    }

    private void CheckDoor() {
        if (requiredButtons.All(id => activePlateUsers.ContainsKey(id)))
            OpenDoor();
        else
            CloseDoor();
    }

    public void OpenDoor() {
        Debug.Log("🟢 문 열림!");
        gameObject.SetActive(false);
    }

    public void CloseDoor() {
        Debug.Log("🔴 문 닫힘!");
        gameObject.SetActive(true);
    }

    public void ResetState() {
        activePlateUsers.Clear();
        CloseDoor();
        Debug.Log("🔄 문 상태 초기화됨");
    }
}
