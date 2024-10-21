using UnityEngine;

namespace MyFPS
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField] private string loadToScene = "MainScene01";
        public SceneFader fader;
        #endregion

        #region Life Cycle
        void Start()
        {
            fader.FadeFrom();
        }
        #endregion

        public void NewGame()
        {
            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            Debug.Log("Load Game");
        }

        public void Options()
        {
            Debug.Log("Options");
        }

        public void Credits()
        {
            Debug.Log("Credits");
        }

        public void Quit()
        {
            Debug.Log("게임을 종료합니다.");
            Application.Quit();
        }
    }
}