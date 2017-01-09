using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjektManager 
{
	private static readonly ObjektManager  instance = new ObjektManager ();
	public 	static 			ObjektManager  Instance
	{
		get { return instance; }
	}

	public List<string> objektSignatur;

	public ObjektManager()
	{
		objektSignatur = new List<string> ();
		objektSignatur.Add ("TWS_1");
		objektSignatur.Add ("TWS_2");
	}
}
