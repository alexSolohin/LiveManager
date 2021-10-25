using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DayPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image mesh;
    private int dayCount;
    [SerializeField] private TextMeshProUGUI text;

    private Color startColor;

    private bool interactable = true;
    private void Start()
    {
        startColor = mesh.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable)
            return;
        mesh.color = Color.cyan;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable)
            return;
        mesh.color = startColor;
    }

    public void SetDayCount(int day)
    {
        dayCount = day;
        text.text = day.ToString("00");
    }

    public void SetNotIncludeMonthColor()
    {
        mesh.color = Color.grey;
        interactable = false;
    }

    public void SetCurrentDayColor()
    {
        mesh.color = Color.green;
    }
}
