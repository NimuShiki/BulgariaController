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

#if UNITY_EDITOR
			if (Input.GetMouseButton(0)) return Input.mousePosition;
#else
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				TouchPos.x = touch.position.x;
				TouchPos.y = touch.position.y;
				return TouchPos;
			}
#endif
			return Vector3.zero;
		}

		static int GetTouchCount()
		{

			int count = 0;
#if UNITY_EDITOR
			if (Input.GetMouseButton(0)) return 1;
#else
			count = Input.touchCount;
#endif
			return count;
		}

	}

}
