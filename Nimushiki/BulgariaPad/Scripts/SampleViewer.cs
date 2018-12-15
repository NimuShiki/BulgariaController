using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nimushiki.BulgariaPad;

public class SampleViewer : MonoBehaviour
{
	[SerializeField]
	private int TouchCount;
	[SerializeField]
	private bool MouseTouch;
	[SerializeField]
	private float Vertical;
	[SerializeField]
	private float Horizontal;
	[SerializeField]
	private bool OnAnalogPad;
	[SerializeField]
	private float AnalogPadRadius;
	[SerializeField]
	private Vector2 AnalogPadPos;
	[SerializeField]
	private bool ButtonA;
	[SerializeField]
	private Vector2 ButtonAPosition;
	[SerializeField]
	private bool ButtonB;
	[SerializeField]
	private Vector2 ButtonBPosition;

	[SerializeField]
	private Vector2[] TouchPositions = new Vector2[3] { Vector2.zero, Vector2.zero, Vector2.zero };
	public Text DebugText;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		TouchCount = Input.touchCount;
		MouseTouch = Input.GetMouseButton(0);
		Vertical = BulgariaPadInput.Vertical;
		Horizontal = BulgariaPadInput.Horizontal;
		OnAnalogPad = BulgariaPadInput.OnAnalogPad;
		AnalogPadRadius = BulgariaPadInput.AnalogPadRadius;
		AnalogPadPos = BulgariaPadInput.AnalogPadPos;
		ButtonAPosition = BulgariaPadInput.ButtonAPosition;
		ButtonA = BulgariaPadInput.ButtonA;
		ButtonBPosition = BulgariaPadInput.ButtonBPosition;
		ButtonB = BulgariaPadInput.ButtonB;

		StringBuilder txt = new StringBuilder("");
		txt.Append(MouseTouch);
		txt.Append("\n");
		txt.Append(Vertical);
		txt.Append("\n");
		txt.Append(Horizontal);
		txt.Append("\n");
		txt.Append(OnAnalogPad);
		txt.Append("\n");
		txt.Append(AnalogPadRadius);
		txt.Append("\n");
		txt.Append(AnalogPadPos);
		txt.Append("\n");
		txt.Append(ButtonAPosition);
		txt.Append("\n");
		txt.Append(ButtonA);
		txt.Append("\n");
		txt.Append(ButtonBPosition);
		txt.Append("\n");
		txt.Append(ButtonB);
		DebugText.text = txt.ToString();

		TouchPositions = TouchUtil.TouchPositions;
	}
}
