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
using Nimushiki.BulgariaPad; と書く<br>

## 使い方
キャリブレーションを実装する（BulgariaPadInitializer.StartCalibration()）<br>
　※ただしメッセージ表示はいい実装が出来てないのでBulgariaPadInitializerをいじって下さい<br>
ボタン位置の初期化をする<br>
　解像度から適当に計算する処理を用意してあります（BulgariaPadInput.ResetPosition()）<br>
BulgariaPadInputの値を使って各自の入力処理を実装する<br>
　Sampleシーンに実装例がありますので参考にして下さい<br>
　BulgariaPadCanvasTest/SampleViewer　…　取得出来る値をインスペクターに表示してあります<br>
　Test/SampleController　…　取得出来る値をいくつか利用したコントローラーの例<br>

## 主な機能
BulgariaPadInput.ResetPosition()　…　画面の解像度からいい感じに初期位置を決める処理。なくてもOK<br>
BulgariaPadInput.Vertical　…　アナログパッドの縦の入力具合。-1から1のfloat<br>
BulgariaPadInput.Horizontal　…　アナログパッドの横の入力具合。-1から1のfloat<br>
BulgariaPadInput.OnAnalogPad　…　タッチ位置がアナログパッドの上かどうかの判定。bool<br>
BulgariaPadInput.AnalogPadRadius …　アナログパッドの半径。float<br>
BulgariaPadInput.AnalogPadPos　…　アナログパッドの中心座標。vector2<br>
BulgariaPadInput.ButtonA　…　Aボタンが押されているか。bool<br>
BulgariaPadInput.ButtonB　…　Bボタンが押されているか。bool<br>
BulgariaPadInput.ButtonAPosition …　Aボタンの座標。vector2<br>
BulgariaPadInput.ButtonBPosition …　Bボタンの座標。vector2<br>
以下、キャリブレーションを自作する人向け<br>
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
マルチタッチに対応していない

## 履歴
2018年12月3日　ver0.0.2　バグ？修正<br>
 unitypackageに不足していたファイルを追加<br>
2018年12月2日　ver0.0.1　初版公開
