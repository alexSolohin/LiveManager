using System;
using UnityEngine;

namespace SaveSystem
{
    [Serializable]
    public class CalendarData
    {
        
    }

    [Serializable]
    public class GoalData
    {
        public string nameGoal;
        public string[] nameTasks;
        public bool[] isTaskCompleted;
    }
    
    public class Saver : MonoBehaviour
    {
        //нам нужно сохранять название гола, название его тасков и выполнена таска или нет         
    }
}