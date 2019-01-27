# BulgariaController
ブルガリアコントローラーを使うためのSDKです

## 導入方法
全部ダウンロードする<br>
or<br>
unitypackageをダウンロードしてインポートする<br>
<br>
Nimushiki/Bulgariapad/Prefab/BulgariaPadCanvasを任意のシーンに配置する<br>
Nimushiki/Bulgariapad/Prefab/BulgariaPadCanvasTestも配置すると便利です<br>
<br>
各種データが欲しいcsファイルの先頭でusing Nimushiki.BulgariaPad; と書く<br>

## 使う時に必要な項目
（必須）キャリブレーションを実装する<br>
　無限に存在する画面サイズ・解像度に対応するために必須です。<br>
　プレイヤーが実機でボタン等から呼び出せるようにして、BulgariaPadInitializer.StartCalibration()を実行して下さい。<br>
　※メッセージ表示はBulgariaPadInitializerを各自書き換えて実装して下さい<br>
（推奨）ボタン位置の初期化をする<br>
　サンプルのシーンでは、起動時に解像度から適当に計算しています。<br>
　SampleControllerのBulgariaPadInput.ResetPosition()<br>
（各自）BulgariaPadInputの値を使って入力処理を実装する<br>
　サンプルのシーンに実装例がありますので参考にして下さい<br>
　BulgariaPadCanvasTest/SampleViewer　…　取得出来る値をインスペクターに表示してあります<br>
　Test/SampleController　…　取得出来る値をいくつか利用したコントローラーの例です<br>

## 主な機能
・エディタ、実機どちらでも動きます<br>
BulgariaPadInput.ResetPosition()　…　画面の解像度からいい感じに初期位置を決める処理。なくてもOK<br>
BulgariaPadInput.Vertical　…　アナログパッドの縦の入力具合。-1から1のfloat<br>
BulgariaPadInput.Horizontal　…　アナログパッドの横の入力具合。-1から1のfloat<br>
BulgariaPadInput.OnAnalogPad　…　タッチ位置がアナログパッドの上かどうかの判定。bool<br>
BulgariaPadInput.AnalogPadRadius …　アナログパッドの半径。float<br>
BulgariaPadInput.AnalogPadPos　…　アナログパッドの中心座標。vector2<br>
BulgariaPadInput.ButtonA　…　Aボタンが押されているか。bool<br>
BulgariaPadInput.ButtonADown　…　Aボタンが押された瞬間だけtrue<br>
BulgariaPadInput.ButtonAUp　…　Aボタンが離された瞬間だけtrue<br>
BulgariaPadInput.ButtonAPosition …　Aボタンの座標。vector2<br>
BulgariaPadInput.ButtonB　…　Bボタンが押されているか。bool<br>
BulgariaPadInput.ButtonBDown　…　Bボタンが押された瞬間だけtrue<br>
BulgariaPadInput.ButtonBUp　…　Bボタンが離された瞬間だけtrue<br>
BulgariaPadInput.ButtonBPosition …　Bボタンの座標。vector2<br>

## 細かい機能
・UnityRemote使用時はマウス入力は出来ません。<br>
・以下、キャリブレーションを自作する人向けのデータ<br>
BulgariaPadInput.SetAnalogPadRadius(float rad)<br>
BulgariaPadInput.SetAnalogPadPosition(Vector2 pos)<br>
BulgariaPadInput.SetButtonAPosition(Vector2 pos)<br>
BulgariaPadInput.SetButtonBPosition(Vector2 pos)<br>

## 内訳
BulgariaPadInput　必須<br>
TouchUtil　必須　タッチとマウスの共通化とかしてます<br>
BulgariaPadInitializer　準必須　キャリブレーションしたりしてます<br>
SampleController　使い方の例<br>
SampleViewer　BulgariaPadInputのデータを可視化するだけのスクリプト。BulgariaPadCanvasTestにくっついてます<br>
ImageMover　ボタン画像の移動だけ担当。なくても動くけど分かりにくい。

## 既知の問題点


## 履歴
2019年1月28日　ver0.2.0　アプデ<br>
2018年12月15日　ver0.1.0　アプデ<br>
2018年12月3日　ver0.0.2　バグ？修正<br>
 unitypackageに不足していたファイルを追加<br>
2018年12月2日　ver0.0.1　初版公開
