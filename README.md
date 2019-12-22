# ScriptsUnityUtil
Unityで使える便利機能群

## General

### ApplicationFocusPosedEventer
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/General/ApplicationFocusPosedEventer.cs

アプリケーションがポーズしたりなどした時にイベントを発行する。

普通にOnApplicationPauseで処理した方が良い気もする。

### RotateOrientationDetection
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/General/RotateOrientationDetection.cs

画面回転の判定処理。

スマートフォンならシステムの値を利用し、PC等なら画面の縦横比から画面の向きから推定する。

### GetEndPointsOfScreen
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/General/GetEndPointsOfScreen.cs

ScreenのWorld上での端点が取得できる。

現在は指定されたカメラに対してNear Clipの端点を取得する。

## Functions

### Math Functions
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/Functions/Math.cs

いくつかの計算系処理

#### PowInt
int用のPow。x^y

#### GreatestCommonResolution
最大ピクセル数と変換元となる画面サイズを渡すと、
最大ピクセル数に収まるサイズに画面サイズを拡縮して返してくれる。

#### GetGreatestCommonDivisor
渡された2つの数の最大公約数を返してくれる。

### XMLUtil
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/Functions/XMLUtil.cs

XMLを読んだり書いたりできる。

## Debugging

### Logger
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/Debugging/Logger.cs

Debug.Log発行装置。

isDebug処理を持っているので適当に投げれて便利。

### LoggerMono
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/Debugging/LoggerMono.cs

LoggerのMonoBehaviour継承版。

InspectorでisDebugが設定できたり、Staticを持たなかったり。

## Struct

### FilePath
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/Structs/FilePath/FilePath.cs

UnityのInspector上でローカルファイルのパスを扱うための構造体。

フルパスの取得やファイル名の取得などができるほか、Inspector上に配置されたときボタンでエクスプローラーなどを開ける。

## Editor

### AnimationSaver
https://github.com/M-T-Asagi/ScriptsUnityUtil/blob/master/Scripts/OnlyOnEditor/AnimationSaver.cs

アタッチされたオブジェクトのTransformをAnimationClipに記録する処理