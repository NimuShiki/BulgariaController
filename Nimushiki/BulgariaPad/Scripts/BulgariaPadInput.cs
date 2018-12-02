using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Nimushiki.BulgariaPad
{
	public static class BulgariaPadInput
	{
		private static float vertical;

		public static float Vertical
		{
			get
			{
				vertical = CalcuVertical();
				return vertical;
			}

		}

		private static float horizontal;

		public static float Horizontal
		{
			get
			{
				horizontal = CalcuHorizontal();
				return horizontal;
			}
		}

		private static bool onAnalogPad;
		public static bool OnAnalogPad
		{
			get
			{
				onAnalogPad = CheckOnAnalogPad();
				return onAnalogPad;
			}
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
			get
			{
				buttonA = CheckOnButtonA();
				return buttonA;
			}
		}
		private static Vector2 buttonAPos;

		public static Vector2 ButtonAPosition
		{
			get
			{
				buttonB = CheckOnButtonB();
				return buttonAPos;
			}
		}

		private static bool buttonB;

		public static bool ButtonB
		{
			get { return buttonB; }
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
			float v = 0;
			if (!TouchUtil.TouchCount.Equals(0))
			{
				v = TouchUtil.TouchPosition.y - analogPadPos.y;
				v /= analogPadRadius;
				v = Mathf.Clamp(v, -1, 1);
			}
			return v;
		}

		static float CalcuHorizontal()
		{
			float h = 0;
			if (!TouchUtil.TouchCount.Equals(0))
			{
				h = TouchUtil.TouchPosition.x - analogPadPos.x;
				h /= analogPadRadius;
				h = Mathf.Clamp(h, -1, 1);
			}
			return h;
		}

		static void UpdateOnAnalogPad(float rad)
		{
			//パッド範囲のバッファ設定　変えられるようにするかも
			if (Mathf.Abs(rad) > 1.5f)
			{
				onAnalogPad = false;
			}
			else
			{
				onAnalogPad = true;
			}
		}

		static bool CheckOnAnalogPad()
		{
			bool isOn = true;
			if (TouchUtil.TouchCount.Equals(0))
			{
				isOn = false;
			}
			else
			{
				float h = (TouchUtil.TouchPosition.x - analogPadPos.x) / analogPadRadius;
				if (Mathf.Abs(h) > 1.5f) isOn = false;
				float v = (TouchUtil.TouchPosition.y - analogPadPos.y) / analogPadRadius;
				if (Mathf.Abs(v) > 1.5f) isOn = false;
			}

			return isOn;
		}


		static bool CheckOnButtonA()
		{
			bool isOn = true;
			if (TouchUtil.TouchCount.Equals(0))
			{
				isOn = false;
			}
			else
			{
				float h = (TouchUtil.TouchPosition.x - buttonAPos.x) / buttonRadius;
				if (Mathf.Abs(h) > 1) isOn = false;
				float v = (TouchUtil.TouchPosition.y - buttonAPos.y) / buttonRadius;
				if (Mathf.Abs(v) > 1) isOn = false;
			}
			return isOn;
		}

		static bool CheckOnButtonB()
		{
			bool isOn = true;
			if (TouchUtil.TouchCount.Equals(0))
			{
				isOn = false;
			}
			else
			{
				float h = (TouchUtil.TouchPosition.x - buttonBPos.x) / buttonRadius;
				if (Mathf.Abs(h) > 1) isOn = false;
				float v = (TouchUtil.TouchPosition.y - buttonBPos.y) / buttonRadius;
				if (Mathf.Abs(v) > 1) isOn = false;
			}
			return isOn;
		}
	}
}
