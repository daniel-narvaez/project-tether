namespace Consystently.Essentials
{
  using UnityEditor;
  using UnityEngine;
  using System;
  using System.Collections.Generic;

  public class GameManager : Manager<GameManager>
  {
    public bool GameIsPaused { get; private set; } = false;
    
    public event Action<GameState> ChangedGameState;

    private GameState currentGameGameState;
    //push to stack for certain states 
    private GameState previousGameState;
    private readonly Stack<GameState> previousGameStates = new Stack<GameState>();

    public void PauseGame ()
    {
      GameIsPaused = !GameIsPaused;
      Time.timeScale = GameIsPaused ? 0f : 1f;
    }

    public void ChangeGameState(GameState newGameState)
    {
      if (currentGameGameState == newGameState)
        return;
      currentGameGameState?.Exit();
      previousGameState = currentGameGameState;
      currentGameGameState = newGameState;
      currentGameGameState?.Enter();
      ChangedGameState?.Invoke(newGameState);
    }

    //primarily for pause screens, menu screens, and other states that can transition to any other state 
    public void ReturnGameState()
    {
      if (previousGameStates.Count < 1)
        return;
      currentGameGameState?.Exit();
      currentGameGameState = previousGameStates.Pop();
      currentGameGameState?.Enter(); 
      ChangedGameState?.Invoke(currentGameGameState);
    }

    //use in state enter functions 
    public void PushOldState()
    {
      previousGameStates.Push(previousGameState);
    }

    protected override void Awake()
    {
      base.Awake();
      ChangeGameState(new MainMenuGameState(this));
    }

    void Update()
    {
      currentGameGameState?.Update();
    }

    public void QuitApplication ()
    {
      #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
      #else
        Application.Quit();
      #endif
    }
  }
}
