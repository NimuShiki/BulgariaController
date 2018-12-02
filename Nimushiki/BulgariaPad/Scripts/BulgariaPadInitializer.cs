using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nimushiki.BulgariaPad;

namespace Nimushiki.BulgariaPad
{
	public class BulgariaPadInitializer : MonoBehaviour
	{

		//キャリブレーション時のメッセージ表示部
		//うまい実装が分からなかったので暫定処理
		//使いやすいように書き換えてください
		void ShowLog(LogType typ)
		{
			string message = "";
			switch (typ)
			{
				case LogType.Analog:
					message = "アナログパッドをグリグリして下さい";
					break;
				case LogType.AnalogOff:
					message = "アナログパッドを離して下さい";
					break;
				case LogType.ButtonA:
					message = "Aボタンを押して下さい";
					break;
				case LogType.ButtonAOff:
					message = "Aボタンを離して下さい";
					break;
				case LogType.ButtonB:
					message = "Bボタンを押して下さい";
					break;
				case LogType.ButtonBOff:
					message = "Bボタンを離して下さい";
					break;
				case LogType.End:
					message = "キャリブレーションが完了しました";
					break;
			}
			Debug.Log(message);
		}
		public void StartCalibration()
		{
			StartCoroutine(Calibration());
		}

		IEnumerator Calibration()
		{
			float waittime = 0;
			Vector2 TouchPos = Vector2.zero;

			ShowLog(LogType.Analog);
			float VMax = 0, VMin = 0, HMax = 0, HMin = 0;
			while (waittime < 3)
			{
				waittime += 0.1f;
				yield return new WaitForSeconds(0.1f);

				if (TouchUtil.TouchCount == 1)
				{
					TouchPos = TouchUtil.TouchPosition;
					if (TouchPos.magnitude == 0) yield return null;
					//初回調整
					if (VMax == 0)
					{
						HMax = HMin = TouchPos.x;
						VMax = VMin = TouchPos.y;
						continue;
					}

					//雑にパッドとボタンを切り分け
					if (TouchPos.x > Screen.width / 2)
					{
						continue;
					}

					//操作範囲調整
					if (TouchPos.x > HMax) HMax = TouchPos.x;
					if (TouchPos.x < HMin) HMin = TouchPos.x;
					if (TouchPos.y > VMax) VMax = TouchPos.y;
					if (TouchPos.y < VMin) VMin = TouchPos.y;
				}
			}
			Vector2 padpos = new Vector2((HMax + HMin) / 2, (VMax + VMin) / 2);
			BulgariaPadInput.SetAnalogPadPosition(padpos);
			float rad = (HMax - HMin + VMax - VMin) / 4;
			BulgariaPadInput.SetAnalogPadRadius(rad);

			ShowLog(LogType.AnalogOff);

			//ボタンを離すまで待つ
			while (TouchUtil.TouchCount != 0)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Vector2 pos = Vector2.zero;

			ShowLog(LogType.ButtonA);
			waittime = 0;
			while (waittime < 3)
			{
				if (TouchUtil.TouchCount == 1)
				{
					TouchPos = TouchUtil.TouchPosition;
					if (TouchPos.magnitude == 0) yield return null; //何の条件だっけ…
					if ((TouchPos - BulgariaPadInput.AnalogPadPos).magnitude > 1) yield return null;
					//雑にパッドとボタンを切り分け
					if (TouchPos.x > Screen.width / 2) yield return null;
					padpos = TouchPos;
					break;
				}
				waittime += 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
			BulgariaPadInput.SetButtonAPosition(padpos);

			//ボタンを離すまで待つ
			ShowLog(LogType.ButtonAOff);
			while (TouchUtil.TouchCount != 0)
			{
				yield return new WaitForSeconds(0.1f);
			}

			ShowLog(LogType.ButtonB);
			waittime = 0;
			while (waittime < 3)
			{
				if (TouchUtil.TouchCount == 1)
				{
					TouchPos = TouchUtil.TouchPosition;
					if (TouchPos.magnitude == 0) yield return null;
					if ((TouchPos - BulgariaPadInput.AnalogPadPos).magnitude > 1) yield return null;
					//雑にパッドとボタンを切り分け
					if (TouchPos.x > Screen.width / 2) yield return null;
					padpos = TouchPos;
					break;
				}
				waittime += 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
			BulgariaPadInput.SetButtonBPosition(padpos);

			//ボタンを離すまで待つ
			ShowLog(LogType.ButtonBOff);
			while (TouchUtil.TouchCount != 0)
			{
				yield return new WaitForSeconds(0.1f);
			}

			ShowLog(LogType.End);
			yield break;
		}


		enum LogType
		{
			Analog,
			AnalogOff,
			ButtonA,
			ButtonAOff,
			ButtonB,
			ButtonBOff,
			End
		}
	}
}
