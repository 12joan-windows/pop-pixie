﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float SpeedModifier(float s);

public class PlayerMovable : MonoBehaviour {

  public float Speed;
  public List<SpeedModifier> SpeedModifiers;

  public Vector2 Movement;

  private Rigidbody2D rb;

  void Awake () {
    rb = GetComponent<Rigidbody2D>();
    SpeedModifiers = new List<SpeedModifier>();
  }

  void FixedUpdate() {
    if ( StateManager.Isnt( State.Playing ) )
      return;

    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Movement += ModifiedSpeed() * new Vector2(moveHorizontal, moveVertical);

    rb.MovePosition(rb.position + Movement * Time.fixedDeltaTime);
    Movement = Vector2.zero;
  }

  float ModifiedSpeed() {
    float speed = Speed;

    foreach (var modifier in SpeedModifiers) {
      speed = modifier(speed);
    }

    return speed;
  }
}
