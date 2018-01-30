using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager 
{
	private static EventManager instance;
	public static EventManager Instance {
		get {
			if (instance == null)
				instance = new EventManager (); 
			return instance;
		}
	}

	public delegate void EventMethode(string eventName, string parameter = "");

	private Dictionary<string, List<EventMethode>> events;

	EventManager()
	{
		events = new Dictionary<string, List<EventMethode>> ();
	}

	public void RegistriereEventListener(string eventTyp, EventMethode methode)
	{
		if (!events.ContainsKey (eventTyp))
			events.Add (eventTyp, new List<EventMethode> ());
		events [eventTyp].Add (methode);
	}

	public void EntferneEventListener(string eventTyp, EventMethode methode)
	{
		if (!events.ContainsKey (eventTyp))
			return;
		events [eventTyp].Remove (methode);
		if (events [eventTyp].Count == 0)
			events.Remove (eventTyp);
	}

	public void Event(string eventTyp, string eventName, string parameter = "")
	{
		if (!events.ContainsKey (eventTyp))
			return;
		foreach (EventMethode e in events[eventTyp])
			e (eventName, parameter);
	}
}
