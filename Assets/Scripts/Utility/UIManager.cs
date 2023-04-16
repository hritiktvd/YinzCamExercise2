using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject UICanvas;
    public List<GameObject> DriverInformation;
    public List<Button> TeamButtons;
    public GameObject generateButton;
    public TMPro.TMP_Text Instruction;

    private void OnEnable()
    {
        EventsManager.onPortalSpawn += HideGenerateButton;
        EventsManager.onPortalEnter += () => spawnUI(true, "Tap on team name to show details");
        EventsManager.onPortalExit += () => spawnUI(false, "Move towards the portal");
    }

    private void OnDisable()
    {
        EventsManager.onPortalSpawn += HideGenerateButton;
        EventsManager.onPortalEnter -= () => spawnUI(true, "Tap on the Team Name");
        EventsManager.onPortalExit -= () => spawnUI(false, "Move Towards the Portal");
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

    private void spawnUI(bool activeState, string instruction) {
        UICanvas.SetActive(activeState);
        changeInstruction(instruction);
    }

    private void changeInstruction(string instruction)  { Instruction.text = instruction;}

    public void CloseButton(int teamID)
    {
        DriverInformation[teamID].SetActive(false);
        TeamButtons[teamID].gameObject.SetActive(true);
    }

    private void HideGenerateButton(){ 
        generateButton.SetActive(false);
        changeInstruction("Move Towards the Portal");
    }

    public void QuitGame() { Application.Quit(); }
}
