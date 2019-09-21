using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySpace
{
    public class UserGUI : MonoBehaviour
    {
        private string guide = "游戏规则：\n小船每次最多载两人最少要有一人\n任意一边恶魔的数量多于牧师，游戏结束\n使用鼠标点击人物可以使其上下船\n点击小船使小船移动\n";
        private IUserAction action;
        private GUIStyle guideStyle;
        private GUIStyle buttonStyle;
        private GUIStyle textStyle;
        public CharacterController characterController;
        public int status;

        void Start()
        {
            status = 0;
            action = Director.GetInstance().CurrentSecnController as IUserAction;
        }

    
        void OnGUI()
        {
            textStyle = new GUIStyle
            {
                fontSize = 60,
                alignment = TextAnchor.MiddleCenter
            };
            guideStyle = new GUIStyle
            {
                fontSize = 30,
                fontStyle = FontStyle.Normal
            };
            guideStyle.normal.textColor = Color.yellow;
            buttonStyle = new GUIStyle("Button")
            {
                fontSize = 30
            };
            GUI.Label(new Rect(50, 200, 100, 50), guide, guideStyle);
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 300, 100, 50), "Priest And Devil", textStyle);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 350, 150, 100), "Restart", buttonStyle))
            {
                status = 0;
                action.Restart();
            }
            if (status != 1 && status != 0)
            {
                //游戏结束
                GUI.Label(new Rect(Screen.width / 2 - 100, 500, 100, 50), "You Lose!", textStyle);

            }
            if (status == 1)
            {
                GUI.Label(new Rect(Screen.width / 2 - 100, 500, 100, 50), "You Win!", textStyle);

            }
        }
        public void SetCharacterCtrl(CharacterController _cc)
        {
            characterController = _cc;
        }

        public void OnMouseDown()
        {
            if (gameObject.name == "boat")
            {
                action.MoveBoat();
            }
            else
            {
                action.CharacterClicked(characterController);
            }
        }
    }
}