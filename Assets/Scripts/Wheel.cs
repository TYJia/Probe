using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour 
{
    public float RotateSpeed = 5;
    private Probe mProbe;


	// Use this for initialization
	void Start () 
	{
        mProbe = transform.root.GetComponent<Probe>();

    }
	
	// Update is called once per frame
	void Update () 
	{
        transform.Rotate(mProbe.mSpeed * RotateSpeed, 0, 0, Space.Self);

    }
}
