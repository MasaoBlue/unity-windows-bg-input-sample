using UnityEngine;
using UnityEngine.UI;
using UnityRawInput;
using System;

public class UnityRawInputScript : MonoBehaviour
{
  private readonly string TIME_FORMAT = @"hh\:mm\:ss\.ffff";

  [SerializeField]
  public Text TextA;

  [SerializeField]
  public Text TextS;

  void Start()
  {
    var workInBackground = true;
    RawKeyInput.Start(workInBackground);
  }

  void Update()
  {
    DateTime now = DateTime.Now;
    if (RawKeyInput.IsKeyDown(RawKey.A))
    {
      TextA.text = now.ToString(TIME_FORMAT);
    }
    if (RawKeyInput.IsKeyDown(RawKey.S))
    {
      TextS.text = now.ToString(TIME_FORMAT);
    }
  }

  private void OnDisable()
  {
    RawKeyInput.Stop();
  }
}
