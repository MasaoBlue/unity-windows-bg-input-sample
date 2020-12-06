using UnityEngine;
using UnityEngine.UI;
using UnityRawInput;
using System;

public class UnityRawInputScript : MonoBehaviour
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

  private readonly bool WORK_IN_BACKGROUND = true;

  private readonly string UP_SUFFIX = " ";

  private void Start()
  {
    RawKeyInput.Start(WORK_IN_BACKGROUND);
  }

  private void Update()
  {
    UpdateText(RawKey.A, textA);
    UpdateText(RawKey.S, textS);
    UpdateText(RawKey.D, textD);
    UpdateText(RawKey.F, textF);
  }

  private void UpdateText(RawKey key, Text text)
  {
    bool isUpped = text.text.EndsWith(UP_SUFFIX);

    if (!RawKeyInput.IsKeyDown(key))
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

  private void OnDisable()
  {
    RawKeyInput.Stop();
  }
}
