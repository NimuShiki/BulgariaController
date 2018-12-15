using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nimushiki.BulgariaPad;

public class SampleController : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		//画面の解像度からいい感じに初期位置を決める処理、なくてもOK
		BulgariaPadInput.ResetPosition();
	}

	// Update is called once per frame
	void Update()
	{

		//パッドの範囲上を触った時だけ移動処理をする
		//パッド範囲の設定値はグリグリ範囲の1.5倍
		//BulgariaPadInput.Verticalの値はグリグリ範囲を超えても-1~1で返る
		if (BulgariaPadInput.Vertical != 0 && BulgariaPadInput.OnAnalogPad)
		{
			Vector3 pos = new Vector3(0, 0, BulgariaPadInput.Vertical * Time.deltaTime);
			transform.position += pos;
		}
		if (BulgariaPadInput.Horizontal != 0 && BulgariaPadInput.OnAnalogPad)
		{
			Vector3 pos = new Vector3(BulgariaPadInput.Horizontal * Time.deltaTime, 0, 0);
			transform.position += pos;
		}

		//値を監視しないで、Buttonコンポーネントに実装してもOK
		if (BulgariaPadInput.ButtonA) transform.RotateAround(transform.position, new Vector3(0, 10, 0), 5);
		if (BulgariaPadInput.ButtonB) transform.RotateAround(transform.position, new Vector3(0, 10, 0), -5);

	}
}
