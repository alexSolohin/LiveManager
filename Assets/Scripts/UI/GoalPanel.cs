using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goalName;

    private TaskPanel tasksPanel;
    
    private int id = 0;
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public void InitTaskPanel(TaskPanel panel)
    {
        tasksPanel = panel;
        tasksPanel.gameObject.SetActive(false);
    }

    public void SetActiveTaskPanel(bool state)
    {
        tasksPanel.gameObject.SetActive(state);
    }
    public void SetGoalName(string text)
    {
        goalName.text = text;
    }
}
