using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
  public static void EndGame()
  {
    SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
  }
}
