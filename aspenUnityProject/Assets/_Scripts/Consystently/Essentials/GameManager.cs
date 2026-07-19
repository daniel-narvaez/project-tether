namespace Consystently.Essentials
{
  using UnityEditor;
  using UnityEngine;

  public class GameManager : Manager<GameManager>
  {
    public bool GameIsPaused { get; private set; } = false;

    public void PauseGame ()
    {
      GameIsPaused = !GameIsPaused;
      Time.timeScale = GameIsPaused ? 0f : 1f;
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
