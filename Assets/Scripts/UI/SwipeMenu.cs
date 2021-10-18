using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwipeMenu : MonoBehaviour
{
   [SerializeField] private RectTransform scrollView;
   [SerializeField] private RectTransform content;
   
   private float scroll_pos = 0;
   private float[] pos;

   private Rect scrollRect;
   private void Start()
   {
      scrollRect = scrollView.rect;
      print(scrollRect);
      for (int i = 0; i < content.childCount; i++)
      {
         content.GetChild(i).GetComponent<RectTransform>().sizeDelta = scrollRect.size;
      }
   }
   
   public void BegginDrag()
   {
      for (int i = 0; i < content.childCount; i++)
      {
         content.GetChild(i).localScale = Vector3.one * 0.8f;
      }
      print("Start drag");
   }

   public void EndDrag()
   {
      var x_pos = Mathf.Abs(content.localPosition.x);
      for (int i = 0; i < content.childCount; i++)
      {
         if (content.GetChild(i).GetComponent<RectTransform>().localPosition.x >= x_pos)
         {
            var rect = content.GetChild(i).GetComponent<RectTransform>();
            var x_size = rect.localPosition.x - rect.rect.width / 2;
            content.localPosition = new Vector3(-x_size, content.localPosition.y, content.localPosition.z);
            content.GetChild(i).localScale = Vector3.one;
            break;
         }
      }
   }
   
   
   
   private void Update()
   {
      
   }
}
