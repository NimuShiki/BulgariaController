# BulgariaController
ブルガリアコントローラーを使うためのSDKです

## 導入方法
全部ダウンロードする<br>
or<br>
unitypackageをダウンロードしてインポートする<br>

Nimushiki/Bulgariapad/Prefab/BulgariaPadCanvasを任意のシーンに配置する<br>
Nimushiki/Bulgariapad/Prefab/BulgariaPadCanvasTestも配置すると便利です<br>

## 使い方
キャリブレーションは必須です（BulgariaPadInitializer.StartCalibration()）<br>
ただしメッセージ表示はいい実装が出来てないのでBulgariaPadInitializerをいじって下さい<br>
ボタンの初期位置は解像度から適当に計算する処理があります（BulgariaPadInput.ResetPosition()）<br>
ボタンの動作はBulgariaPadInput.Buttonのbool判定を監視してもいいし、Buttonコンポーネントにくっつけても問題ないです<br>
<br>
Sampleシーンに実装例がありますので参考にして下さい<br>

## 内訳
BulgariaPadInput　必須<br>
TouchUtil　必須　タッチとマウスの共通化とかしてます<br>
BulgariaPadInitializer　準必須　キャリブレーションしたりしてます<br>
SampleController　使い方の例<br>
SampleViewer　BulgariaPadInputのデータを見るだけのスクリプト。BulgariaPadCanvasTestにくっついてます<br>
ImageMover　ボタン画像の移動だけ担当
