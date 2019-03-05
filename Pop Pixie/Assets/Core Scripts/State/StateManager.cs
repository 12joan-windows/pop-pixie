﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State : int { Playing, Dialogue, Lore, DialoguePrompt };

public class StateManager : MonoBehaviour {
  public static int State;

  public static bool Is(object state) {
    return State == (int)state;
  }

  public static bool Isnt(object state) {
    return !Is(state);
  }

  public static void SetState (object state) {
    State = (int)state;
  }
}
