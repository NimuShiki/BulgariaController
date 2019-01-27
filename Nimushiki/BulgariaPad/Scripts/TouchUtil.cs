using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nimushiki.BulgariaPad
{
	/// <summary>
	/// タッチorクリックを共通化する
	/// </summary>
	public static class TouchUtil
	{
		static bool isRemote
		{
			get
			{
#if UNITY_EDITOR
				return UnityEditor.EditorApplication.isRemoteConnected;
#else
            	return false;
#endif
			}
		}

		public static int TouchCount
		{
			get
			{
				return GetTouchCount();
			}
		}
		public static Vector2[] TouchPositions
		{
			get
			{
				return GetTouchPositions();
			}
		}


		static Vector2[] GetTouchPositions()
		{
			Vector2[] poss = new Vector2[4];

			if (Application.isEditor && !isRemote)
			{
				if (Input.GetMouseButton(0)) poss[0] = Input.mousePosition;
			}
			else
			{
				for (int i = 0; i < Input.touchCount; i++)
				{
					poss[i] = Input.touches[i].position;
				}
			}
			return poss;
		}

		static int GetTouchCount()
		{
			int count = 0;
			if (Application.isEditor && !isRemote)
			{
				if (Input.GetMouseButton(0)) count = 1;
			}
			else
			{
				count = Input.touchCount;
			}
			return count;
		}

		public static bool IsTouchUp (int num) {
			if (Application.isEditor && !isRemote) {
				return Input.GetMouseButtonUp (0);
			} else {
				if (GetTouchCount () < num) {
					return false;
				}
				return Input.GetTouch (num).phase == TouchPhase.Ended;
			}
		}

		public static bool IsTouchDown (int num) {
			if (Application.isEditor && !isRemote) {
				return Input.GetMouseButtonDown (0);
			} else {
				if (GetTouchCount () < num) {
					return false;
				}
				return Input.GetTouch (num).phase == TouchPhase.Began;
			}
		}

	}

}
