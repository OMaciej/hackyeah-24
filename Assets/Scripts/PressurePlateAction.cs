using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This is very important if we want to restart the level
public class PressurePlateAction : MonoBehaviour {
  // Use this for initialization
  void Start () {
    
  }
  
  // Update is called once per frame
  void Update () {
    
  }

  public Action onEnterAction;
  public Action onExitAction;

  bool isAllowedToPress(Collider2D other) {
    return other.GetComponent<CanPressPressurePlate>() != null;
  }

  // This function is called every time another collider overlaps the trigger collider
  void OnTriggerEnter2D (Collider2D other){
    if (isAllowedToPress(other)) {
      Debug.Log("Plate pressed");
      Debug.Log(other);
      onEnterAction.PerformAction();
    }
  }

  void OnTriggerExit2D (Collider2D other) {
    if (isAllowedToPress(other)) {
      Debug.Log("Plate released");
      Debug.Log(other);
      onExitAction.PerformAction();
    }
  }
}