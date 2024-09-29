using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is very important if we want to restart the level
public class PressurePlateAction : MonoBehaviour {
  public Action onEnterAction;
  public Action onExitAction;

  [SerializeField] private SpriteRenderer spriteRenderer;
  [SerializeField] private Sprite onSprite;
  [SerializeField] private Sprite offSprite;

    private void Start()
    {
        spriteRenderer.sprite = offSprite;
    }

    bool isAllowedToPress(Collider2D other) {
       return other.GetComponent<CanPressPressurePlate>() != null;
    }

  // This function is called every time another collider overlaps the trigger collider
  void OnTriggerEnter2D (Collider2D other){
    if (isAllowedToPress(other)) {
      spriteRenderer.sprite = onSprite;
      onEnterAction.PerformAction();
    }
  }

  void OnTriggerExit2D (Collider2D other) {
    if (isAllowedToPress(other)) {
      spriteRenderer.sprite = offSprite;
      onExitAction.PerformAction();
    }
  }
}