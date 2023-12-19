using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class NavInitMenu : MonoBehaviour
{
    [SerializeField] GameObject canvasCreateGame, canvasNewGame;
    public void CreateGame()
    {
        canvasNewGame.gameObject.SetActive(false);
        canvasCreateGame.gameObject.SetActive(true);
    }
    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
