using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject UICanvas;
    public List<GameObject> DriverInformation;
    public List<Button> TeamButtons;

    private void OnEnable()
    {
        EventsManager.onPortalEnter += () => spawnUI(true);
        EventsManager.onPortalExit += () => spawnUI(false);
    }

    private void OnDisable()
    {
        EventsManager.onPortalEnter -= () => spawnUI(true);
        EventsManager.onPortalExit -= () => spawnUI(false);
    }

    void Start() { 
        UICanvas.SetActive(false);
        HideAllTeamInfo();
    }

    public void spawnTeamInfo(int teamID)
    {
        DriverInformation[teamID].SetActive(true);
        TeamButtons[teamID].gameObject.SetActive(false);
    }

    private void HideAllTeamInfo()
    {
        foreach (var Team in DriverInformation) { Team.SetActive(false); }
    }

    private void spawnUI(bool activeState) {UICanvas.SetActive(activeState); }

    public void CloseButton(int teamID)
    {
        DriverInformation[teamID].SetActive(false);
        TeamButtons[teamID].gameObject.SetActive(true);
    }
}
