using UnityEngine;
using System.Collections;

public class ListItemBase {
	public ListItemBase Prev;
	public ListItemBase Next;

	void Awake () {
		Prev = Next = null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
