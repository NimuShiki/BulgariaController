using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Nimushiki.BulgariaPad
{
	public static class BulgariaPadInput
	{
		public static float Vertical
		{
			get { return CalcuVertical(); }
		}
		public static float Horizontal
		{
			get { return CalcuHorizontal(); }
		}
		public static bool OnAnalogPad
		{
			get { return CheckOnAnalogPad(); }
		}
		private static float analogPadRadius;
		public static float AnalogPadRadius
		{
			get { return analogPadRadius; }
		}
		private static Vector2 analogPadPos;
		public static Vector2 AnalogPadPos
		{
			get { return analogPadPos; }
		}
		private static float buttonRadius;
		public static float ButtonRadius
		{
			get { return buttonRadius; }
		}
		private static bool buttonA;
		public static bool ButtonA
		{
			get { return CheckOnButtonA(); }
		}
		private static Vector2 buttonAPos;
		public static Vector2 ButtonAPosition
		{
			get { return buttonAPos; }
		}
		private static bool buttonB;
		public static bool ButtonB
		{
			get { return CheckOnButtonB(); }
		}
		private static Vector2 buttonBPos;
		public static Vector2 ButtonBPosition
		{
			get { return buttonBPos; }
		}

		public static void ResetPosition()
		{
			analogPadPos = new Vector2(Screen.width / 4, Screen.height / 8);
			analogPadRadius = Screen.width / 8;
			buttonAPos = new Vector2(Screen.width * 7 / 8, Screen.height * 3 / 16);
			buttonBPos = new Vector2(Screen.width * 5 / 8, Screen.height * 1 / 16);
			buttonRadius = Screen.width / 16;
		}

		public static void SetAnalogPadRadius(float rad)
		{
			analogPadRadius = rad;
		}

		public static void SetAnalogPadPosition(Vector2 pos)
		{
			analogPadPos = pos;
		}

		public static void SetButtonAPosition(Vector2 pos)
		{
			buttonAPos = pos;
		}

		public static void SetButtonBPosition(Vector2 pos)
		{
			buttonBPos = pos;
		}

		static float CalcuVertical()
		{
			Vector2 pos = ReturnTouchPositionWithinRange(analogPadPos, analogPadRadius);
			if (pos != Vector2.zero)
			{
				pos = (pos - analogPadPos) / analogPadRadius;
				return Mathf.Clamp(pos.y, -1, 1);
			}
			return 0;
		}

		static float CalcuHorizontal()
		{
			Vector2 pos = ReturnTouchPositionWithinRange(analogPadPos, analogPadRadius);
			if (pos != Vector2.zero)
			{
				pos = (pos - analogPadPos) / analogPadRadius;
				return Mathf.Clamp(pos.x, -1, 1);
			}
			return 0;
		}

		static bool CheckOnAnalogPad()
		{
			bool isOn = true;
			if (ReturnTouchPositionWithinRange(analogPadPos, analogPadRadius) == Vector2.zero) isOn = false;
			return isOn;
		}


		static bool CheckOnButtonA()
		{
			bool isOn = true;
			if (ReturnTouchPositionWithinRange(buttonAPos, buttonRadius) == Vector2.zero) isOn = false;
			return isOn;
		}

		static bool CheckOnButtonB()
		{
			bool isOn = true;
			if (ReturnTouchPositionWithinRange(buttonBPos, buttonRadius) == Vector2.zero) isOn = false;
			return isOn;
		}

		static Vector2 ReturnTouchPositionWithinRange(Vector2 CheckPos, float CheckRadius)
		{
			for (int i = 0; i < TouchUtil.TouchCount; i++)
			{
				Vector2 distance = (TouchUtil.TouchPositions[i] - CheckPos) / CheckRadius;
				if (Mathf.Abs(distance.magnitude) < 1) return TouchUtil.TouchPositions[i];
			}
			return Vector2.zero;
		}
	}
}
