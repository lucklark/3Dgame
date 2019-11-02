using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {
    private UserAction action;
    private SceneController controller;
    GUIStyle buttonStyle;
    GUIStyle countDownStyle;
    GUIStyle finishStyle;
    GUIStyle textStyle;

    void Start() {
        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 15;
        buttonStyle.normal.textColor = Color.red;
        countDownStyle = new GUIStyle();
        countDownStyle.fontSize = 25;
        countDownStyle.normal.textColor = Color.red;
        finishStyle = new GUIStyle();
        finishStyle.fontSize = 40;
        finishStyle.normal.textColor = Color.red;
        textStyle = new GUIStyle();
        textStyle.fontSize = 40;
        textStyle.normal.textColor = Color.red;
    }

    private void Update() {
        action = Director.GetInstance().CurrentSceneController as UserAction;
        controller = Director.GetInstance().CurrentSceneController as SceneController;
        if (controller.getGameState().Equals(GameState.RUNNING)) {
            // 获取键盘输入
            float translationX = Input.GetAxis("Horizontal");
            float translationZ = Input.GetAxis("Vertical");
            //移动玩家
            action.MovePlayer(translationX, translationZ);
        }
    }

    private void OnGUI() {
        controller = Director.GetInstance().CurrentSceneController as SceneController;
        string buttonText = "";
        if (controller.getGameState().Equals(GameState.START) || controller.getGameState().Equals(GameState.PAUSE)) {
            buttonText = "Start";
        }
        if (controller.getGameState().Equals(GameState.LOSE)) {
            buttonText = "Restart";
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 200, 200, 50), "Game Over!", finishStyle);
        }
        if (controller.getGameState().Equals(GameState.WIN)) {
            buttonText = "Restart";
            GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 200, 200, 50), "You Win!", finishStyle);
        }
        if (controller.getGameState().Equals(GameState.RUNNING)) {
            buttonText = "Pause";
        }
        GUI.Label(new Rect(Screen.width / 2 - 100, 5, 100, 50),
            "Use WASD or ↑↓←→ to move!", textStyle);
        GUI.Label(new Rect(5, Screen.height / 2 - 210, 100, 50),
            "Time: " + Director.GetInstance().leaveSeconds.ToString(), countDownStyle);

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 200, 100, 50), buttonText, buttonStyle)) {
            // 按下按钮控制游戏状态
            if (buttonText == "Pause") {
                controller.Pause();
            } else if (buttonText == "Start") {
                controller.Begin();
            } else if (buttonText == "Restart") {
               controller.Restart();
            }
        }
    }
}
