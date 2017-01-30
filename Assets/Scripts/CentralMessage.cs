using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralMessage : MonoBehaviour {

	internal SimulatedProbe mSimulatedProbe;
	private TextMesh mTextMesh;

	// Use this for initialization
	void Start () 
	{
		mTextMesh = GetComponent<TextMesh> ();
		mTextMesh.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SetProbe(int i)
	{
		foreach (SimulatedProbe sp in FindObjectsOfType<SimulatedProbe>())
		{
			if (i == sp.NameId) 
			{
				mSimulatedProbe = sp;
			}
		}
		ShowMessage ();
	}

	public void ShowMessage()
	{
		mTextMesh.text = "NameId: " + mSimulatedProbe.NameId + "\n"+
			"Declared Position: " + mSimulatedProbe.mPosition + "\n"+
			"Predicted Position: " + mSimulatedProbe.mPredictedPos + "\n"+
			"Direction: " + mSimulatedProbe.mDirection;
	}
}
