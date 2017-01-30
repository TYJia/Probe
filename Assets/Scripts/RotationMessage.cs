using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMessage : AMessage 
{
	internal Vector3 Direction;
	internal Vector3 Speed;
	internal Vector3 Position;
	internal float Angle;
	internal void AddContent(sMessageContent mMessageContent, float angle)
	{
		base.AddContent(mMessageContent);
		Direction = mMessageContent.mDirection;
		Speed = mMessageContent.mSpeed;
		Angle = angle;
		Position = mMessageContent.mPosition;
		mMessageType = eMessageType.Rotation;
	}
}