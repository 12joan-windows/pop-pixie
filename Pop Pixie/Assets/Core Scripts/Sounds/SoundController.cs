﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
  public AudioSource Player;
  public float BaseVolume = 1f;
  public bool OneShot = false;

  public void Play (AudioClip sound) {
    if ( OneShot ) {
      Player.PlayOneShot(sound);
    } else {
      Player.clip = sound;
      Player.Play();
    }
  }

  public void Stop() {
    Player.Stop();
  }

  void Update() {
    Player.volume = BaseVolume * (float) OptionsData.SoundsVolume;
  }
}
