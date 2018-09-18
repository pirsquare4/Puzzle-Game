using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public PauseMenu pauseMenu;

    private void Update()
    {
        if (!pauseMenu.IsPaused()) {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
    public void DoSlowmotion() {
        if (!pauseMenu.IsPaused()) {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}
