using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
   [SerializeField] private GameObject taskPanelPrefab;
   [SerializeField] private GameObject goalPrefab;
   [SerializeField] private RectTransform scrollView;
   [SerializeField] private RectTransform content;
   [SerializeField] private Transform centerPanel;
   
   private float[] pos;

   private List<GoalPanel> goalPanels;

   private Rect scrollRect;
   private void Start()
   {
      goalPanels = new List<GoalPanel>();
      scrollRect = scrollView.rect;
      for (int i = 0; i < 5; i++)
      {
         var goalPanel = Instantiate(goalPrefab, content).GetComponent<GoalPanel>();
         goalPanel.ID = i;
         var tasksPanel = Instantiate(taskPanelPrefab, centerPanel).GetComponent<TaskPanel>();
         goalPanel.InitTaskPanel(tasksPanel);
         goalPanels.Add(goalPanel);
      }
      for (int i = 0; i < content.childCount; i++)
      {
         content.GetChild(i).GetComponent<RectTransform>().sizeDelta = scrollRect.size;
         content.GetChild(i).localScale = Vector3.one;
      }

      goalPanels[0].SetActiveTaskPanel(true);
   }
   
   public void BegginDrag()
   {
      StopAllCoroutines();
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
            StartCoroutine(SmoothMove(x_size, content.GetChild(i)));
            StartCoroutine(SizeUpPanel(content.GetChild(i)));
            content.GetChild(i).localScale = Vector3.one * 0.9f;
            goalPanels[i].SetActiveTaskPanel(true);
            for (int j = i + 1; j < content.childCount; j++)
               goalPanels[j].SetActiveTaskPanel(false);
            break;
         }
      }
   }

   private float speed = 10f;
   private IEnumerator SmoothMove(float x_size, Transform obj)
   {
      while (content.localPosition.x != -x_size)
      {
         content.localPosition = new Vector3(Mathf.SmoothStep(content.localPosition.x, -x_size, Time.deltaTime * speed), content.localPosition.y, content.localPosition.z);
         if (obj.localScale.x < 0.9f)
            obj.localScale = Vector3.one * Mathf.SmoothStep(obj.localScale.x, 0.9f, Time.deltaTime * speed);
         yield return null;
      }
   }
   
   private IEnumerator SizeUpPanel(Transform obj)
   {
      yield return new WaitForSeconds(1f);
      while (obj.localScale.x < 1f)
      {
         obj.localScale = Vector3.one * Mathf.SmoothStep(obj.localScale.x, 1f, Time.deltaTime * speed);
         yield return null;
      }
   }
}
