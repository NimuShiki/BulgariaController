using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nimushiki.BulgariaPad
{
	/// <summary>
	/// タッチorクリックを共通化する
	/// </summary>
	public static class TouchUtil
	{

		public static int TouchCount
		{
			get
			{
				return GetTouchCount();
			}
		}
		public static Vector3 TouchPosition
		{
			get
			{
				return GetTouchPosition();
			}
		}


		static Vector3 GetTouchPosition()
		{
			if (Application.isEditor)
			{
				if (Input.GetMouseButton(0)) return Input.mousePosition;
			}
			else
			{
				if (Input.touchCount > 0)
				{
					Touch touch = Input.GetTouch(0);
					return touch.position;
				}

			}
			return Vector3.zero;
		}

		static int GetTouchCount()
		{
			int count = 0;
			if (Application.isEditor)
			{
				if (Input.GetMouseButton(0)) count = 1;
			}
			else
			{
				count = Input.touchCount;
			}
			return count;
		}

	}

}
