using UnityEngine;
using UnityEngine.UI;
using System;
using SharpDX.DirectInput;

public class SharpDxScript : MonoBehaviour
{

  [SerializeField]
  public NowScript nowScript;

  [SerializeField]
  public Text textA;

  [SerializeField]
  public Text textS;

  [SerializeField]
  public Text textD;

  [SerializeField]
  public Text textF;

  private Keyboard keyboard;

  private readonly int BUFFER_SIZE = 128;

  private readonly string UP_SUFFIX = " ";

  private void Start()
  {
    DirectInput directInput = new DirectInput();
    if (directInput == null)
    {
      throw new Exception("can't use DirectInput");
    }

    InitKeyboard(directInput);
  }

  private void Update()
  {
    if (keyboard == null)
    {
      return;
    }

    keyboard.Acquire();
    keyboard.Poll();

    UpdateText(Key.A, textA);
    UpdateText(Key.S, textS);
    UpdateText(Key.D, textD);
    UpdateText(Key.F, textF);
  }

  private void UpdateText(Key key, Text text)
  {
    bool isUpped = text.text.EndsWith(UP_SUFFIX);

    if (!IsInputKeyboard(key))
    {
      if (isUpped)
      {
        return;
      }

      text.text += UP_SUFFIX;
      return;
    }

    if (isUpped)
    {
      text.text = nowScript.GetNow();
    }
  }

  private void InitKeyboard(DirectInput directInput)
  {
    keyboard = new Keyboard(directInput);
    if (keyboard == null)
    {
      throw new Exception("can't use keyboard with DirectInput");
    }
    keyboard.Properties.BufferSize = BUFFER_SIZE;
  }

  public bool IsInputKeyboard(Key key)
  {
    if (keyboard == null)
    {
      return false;
    }

    KeyboardState state = keyboard.GetCurrentState();
    return state.IsPressed(key);
  }
}
