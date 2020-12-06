# unity-windows-bg-input-sample

On Windows, detect input in a Unity application running in the background.

## Operating environment

- Windows 10 Pro
- Unity 2019.4.12f1 & 2020.1.8f1

## Usage

When you start SampleScene, the input time of A,S,D,F on the keyboard is displayed on the screen.

## Limitations

UnityRawInput only works when the window is out of focus. (because it's used with SharpDX)
