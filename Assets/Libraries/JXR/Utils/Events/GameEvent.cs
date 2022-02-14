using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace JXR.Utils
{
[CreateAssetMenu(fileName = "MyGameEvent", menuName = "JXR/GameEvent")]
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();
    #if UNITY_EDITOR
    [SerializeField] private List<MyEventListeners> EventListeners = new List<MyEventListeners>();
    #endif

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

    #if UNITY_EDITOR
    public void SerializeListeners()
    {
        GameEventListener[] listeners = FindObjectsOfType<GameEventListener>();
        foreach (var item in listeners)
        {
            if (item.Event.Equals(this))
            {
                MyEventListeners myEventListener = new MyEventListeners(item.name);
                int myCount = item.Response.GetPersistentEventCount();
                if(myCount != 0)
                {
                    for(int i = 0; i < myCount; i++)
                    {
                        myEventListener.AddPersistentListenerInfo(item.Response.GetPersistentTarget(i), item.Response.GetPersistentMethodName(i));
                    }
                }
                EventListeners.Add(myEventListener);
            }
        }
    }
    public void DeserializeListeners()
    {
        EventListeners.Clear();
    }
    #endif
}
#if UNITY_EDITOR
[System.Serializable]
public class MyEventListeners
{
    [SerializeField] private string objectName = "";
    [SerializeField] private List<MyEventCalls> eventCalls = new List<MyEventCalls>();
    public MyEventListeners(string _objectName)
    {
        objectName =_objectName;
    }
    public void AddPersistentListenerInfo(Object _target, string _method)
    {
        eventCalls.Add(new MyEventCalls(_target, _method));
    }
}
[System.Serializable]
public class MyEventCalls
{
    [SerializeField] private Object targetObject;
    [SerializeField] private string targetMethod = "";

    public MyEventCalls(Object _targetObject, string _targetMethod)
    {
        targetObject = _targetObject;
        targetMethod = _targetMethod;
    }
}
#endif
}