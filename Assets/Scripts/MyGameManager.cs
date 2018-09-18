using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour {
    public static int currentScore;
    public static int highScore;

    public static int currentLevel = 1;
    public static int UnlockedLevel;

    public static void CompleteLevel() {
        currentLevel += 1;
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
    }

}
