using UnityEngine;
using System;

public class NowScript : MonoBehaviour
{
  private readonly string TIME_FORMAT = @"HH\:mm\:ss\.ffff";

  private DateTime now;

  void Start()
  {
    now = DateTime.Now;
  }

  void Update()
  {
    now = DateTime.Now;
  }

  public string GetNow()
  {
    return now.ToString(TIME_FORMAT);
  }
}
