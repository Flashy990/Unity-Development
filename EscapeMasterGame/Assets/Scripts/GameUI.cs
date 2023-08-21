using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public GameObject gameLose;
    public GameObject gameWin;
    bool gameIsOver;
    
    // Start is called before the first frame update
    void Start()
    {
        // subscribe ShowGameLoseUI and ShowGameWinUI to the appropriate action events
        Guard.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        FindObjectOfType<Player>().OnReachedEndOfLevel += ShowGameWinUI;
    }

    // Update is called once per frame
    void Update()
    {
        // restart with spacebar is game is over
        if (gameIsOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void ShowGameWinUI()
    {
        OnGameOver(gameWin);
    }

    void ShowGameLoseUI()
    {
        OnGameOver(gameLose);
    }

    void OnGameOver(GameObject gameOverUI) {
        // end of game routine
        gameOverUI.SetActive(true);
        gameIsOver = true;
        Guard.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        FindObjectOfType<Player>().OnReachedEndOfLevel -= ShowGameWinUI;
    }

}
