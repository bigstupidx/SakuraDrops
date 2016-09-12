using UnityEngine;
using System;
using System.Collections;

public class Clock : Singleton<Clock> {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// CurrentTime
	public int currentTime
	{
		get
		{
			return timestamp;
		}
	}

	// Timestamp
	public int timestamp
	{
		get
		{
			long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
			ticks /= 10000000; //Convert windows ticks to seconds
			return (int)ticks;
		}
	}
}