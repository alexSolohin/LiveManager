using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject monthPanelPref;
    
    private void Start()
    {
        StartCoroutine(CreateCalendar());
    }

    private IEnumerator CreateCalendar()
    {
        var yearCounter = DateTime.Today.Year;
        var monthCounter = DateTime.Today.Month - 1;
        for (int i = 0; i < 10; i++)
        {
            var montPanel = Instantiate(monthPanelPref, content).GetComponent<MonthPanel>();
            var dateTime = new DateTime(yearCounter, monthCounter, 1);
            monthCounter++;
            if (monthCounter > 12)
            {
                monthCounter = 1;
                yearCounter++;
            }
            yield return null;
            montPanel.CreateMonth(dateTime);
        }
    }
}
