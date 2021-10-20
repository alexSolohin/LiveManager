using System.Collections.Generic;
using UnityEngine;

public class SwipeMenu : MonoBehaviour
{
   [SerializeField] private GameObject taskPanelPrefab;
   [SerializeField] private GameObject goalPrefab;
   [SerializeField] private RectTransform scrollView;
   [SerializeField] private RectTransform content;
   [SerializeField] private Transform centerPanel;
   
   private float[] pos;

   private List<GoalPanel> goalPanels;
   private string[] goalsNames;
   
   private Rect scrollRect;
   private void Start()
   {
      goalsNames = new string[5];
      goalsNames[0] = "Morning";
      goalsNames[1] = "Личное";
      goalsNames[2] = "Gamedev";
      goalsNames[3] = "Work";
      goalsNames[4] = "English";
      goalPanels = new List<GoalPanel>();
      scrollRect = scrollView.rect;
      for (int i = 0; i < 5; i++)
      {
         var goalPanel = Instantiate(goalPrefab, content).GetComponent<GoalPanel>();
         goalPanel.SetGoalName(goalsNames[i]);
         goalPanel.ID = i;
         var tasksPanel = Instantiate(taskPanelPrefab, centerPanel).GetComponent<TaskPanel>();
         goalPanel.InitTaskPanel(tasksPanel);
         goalPanels.Add(goalPanel);
      }
      for (int i = 0; i < content.childCount; i++)
      {
         content.GetChild(i).GetComponent<RectTransform>().sizeDelta = scrollRect.size;
      }

      goalPanels[0].SetActiveTaskPanel(true);
   }
   
   public void BegginDrag()
   {
      for (int i = 0; i < content.childCount; i++)
      {
         content.GetChild(i).localScale = Vector3.one * 0.8f;
         goalPanels[i].SetActiveTaskPanel(false);
      }
   }

   public void EndDrag()
   {
      var x_pos = Mathf.Abs(content.localPosition.x);
      for (int i = 0; i < content.childCount; i++)
      {
         goalPanels[i].SetActiveTaskPanel(false);
         if (content.GetChild(i).GetComponent<RectTransform>().localPosition.x >= x_pos)
         {
            var rect = content.GetChild(i).GetComponent<RectTransform>();
            var x_size = rect.localPosition.x - rect.rect.width / 2;
            content.localPosition = new Vector3(-x_size, content.localPosition.y, content.localPosition.z);
            content.GetChild(i).localScale = Vector3.one;
            goalPanels[i].SetActiveTaskPanel(true);
            for (int j = i + 1; j < content.childCount; j++)
               goalPanels[j].SetActiveTaskPanel(false);
            break;
         }
      }
   }
}
