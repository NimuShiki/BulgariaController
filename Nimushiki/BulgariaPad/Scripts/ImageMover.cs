using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nimushiki.BulgariaPad;
public class ImageMover : MonoBehaviour
{

	public Transform AnalogPadObj;
	public Transform ButtonAObj;
	public Transform ButtonBObj;

	// Use this for initialization
	void Start()
	{
		UpdatePosition();
	}

	// Update is called once per frame
	void Update()
	{
		UpdatePosition();
	}

	void UpdatePosition()
	{
		AnalogPadObj.position = BulgariaPadInput.AnalogPadPos;
		ButtonAObj.position = BulgariaPadInput.ButtonAPosition;
		ButtonBObj.position = BulgariaPadInput.ButtonBPosition;
	}

}
