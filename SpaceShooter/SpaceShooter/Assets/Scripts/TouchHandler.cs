using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour
{
  public bool PlayInEditor;
  public GameObject panelPause;
  public GameObject playerHolder;
  Done_PlayerController playerController;
  // Use this for initialization
  void Start()
  {
    playerController = playerHolder.GetComponent<Done_PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    HandleTouchInput();
  }

  public void HandleTouchInput()
  {
    if(PlayInEditor)
      return;
    
    if (Input.touchCount > 0)
    {
      if(Time.timeScale==0)
        PauseGame(false);

      Touch touch = Input.GetTouch(0);
      switch (touch.phase)
      {
        case TouchPhase.Began:
        case TouchPhase.Stationary:
          break;
        case TouchPhase.Moved:
          var delta = touch.deltaPosition;
          Debug.Log("X: " + delta.x);
          playerController.MovePlayer(delta.x, 0.0f, delta.y);
          break;
        case TouchPhase.Ended:
          break;
      }
    }
    else
    {
      playerController.StopMovement();
      PauseGame(true);
    }
  }


  public void PauseGame(bool pause)
  {
    Time.timeScale = pause ? 0 : 1;
    panelPause.SetActive(pause);
  }
}
