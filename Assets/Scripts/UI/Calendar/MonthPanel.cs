using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonthPanel : MonoBehaviour
{
    [SerializeField] private GameObject dayPanelPref;
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform weekPanel;
    [SerializeField] private TextMeshProUGUI monthNameText;
    
    private void Start()
    {
        DateTime dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        // CreateMonth(dateTime);
    }

    public void CreateMonth(DateTime dateTime)
    {
        StartCoroutine(WaitGridSizeCoroutine(dateTime));
    }

    private IEnumerator WaitGridSizeCoroutine(DateTime dateTime)
    {
        yield return null;
        yield return null;
        var calendar = CultureInfo.InvariantCulture.Calendar;
        var firstDayInMonth = (int)calendar.GetDayOfWeek(dateTime);
        var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        gridLayout.cellSize = new Vector2(rectTransform.rect.width / 7, rectTransform.rect.height / 5);
        monthNameText.text = dateTime.ToString("MMMM");
        var monthBefore = dateTime.Month - 1;
        var yearBefore = dateTime.Year;
        if (monthBefore == 0)
        {
            yearBefore -= 1;
            monthBefore = 12;
        }
        var beforeMonthCounter = DateTime.DaysInMonth(yearBefore, monthBefore) - firstDayInMonth + 2;
        var currentDay = DateTime.Now;
        var afterMonthCounter = 1;
        for (int i = 0; i < 35; i++)
        {
            var dayPanel = Instantiate(dayPanelPref, rectTransform).GetComponent<DayPanel>();
            if (i < firstDayInMonth - 1)
            {
                dayPanel.SetDayCount(beforeMonthCounter++);
                dayPanel.SetNotIncludeMonthColor();
            }
            else if (i >= firstDayInMonth - 1 && i < daysInMonth + firstDayInMonth - 1)
            {
                dayPanel.SetDayCount(i - firstDayInMonth + 2);
                if (i - firstDayInMonth + 2 == currentDay.Day && dateTime.Month == currentDay.Month)
                    dayPanel.SetCurrentDayColor();
            }
            else if (i >= daysInMonth + firstDayInMonth - 1)
            {
                dayPanel.SetDayCount(afterMonthCounter++);
                dayPanel.SetNotIncludeMonthColor();
            }
        }
    }
}
