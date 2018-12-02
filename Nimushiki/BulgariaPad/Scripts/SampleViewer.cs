using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nimushiki.BulgariaPad;

public class SampleViewer : MonoBehaviour
{

	[SerializeField]
	private float Vertical;
	public float Horizontal;
	public bool OnAnalogPad;
	public float AnalogPadRadius;
	public Vector2 AnalogPadPos;
	public bool ButtonA;
	public Vector2 ButtonAPosition;
	public bool ButtonB;
	public Vector2 ButtonBPosition;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vertical = BulgariaPadInput.Vertical;
		Horizontal = BulgariaPadInput.Horizontal;
		OnAnalogPad = BulgariaPadInput.OnAnalogPad;
		AnalogPadRadius = BulgariaPadInput.AnalogPadRadius;
		AnalogPadPos = BulgariaPadInput.AnalogPadPos;
		ButtonA = BulgariaPadInput.ButtonA;
		ButtonAPosition = BulgariaPadInput.ButtonAPosition;
		ButtonB = BulgariaPadInput.ButtonB;
		ButtonBPosition = BulgariaPadInput.ButtonBPosition;
	}
}
