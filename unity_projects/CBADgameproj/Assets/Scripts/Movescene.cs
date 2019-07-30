namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Movescene : MonoBehaviour
    {
        /// <summary>
        /// Moves the scene.
        /// </summary>
        /// <param name="scenename">Scenename.</param>
        public void MoveScene(string scenename)
        {
            SceneManager.LoadScene(scenename);
        }

        /// <summary>
        /// make the scene over it.
        /// </summary>
        /// <param name="scenename">Scenename.</param>
        public void MoveSceneadditive(string scenename)
        {
            SceneManager.LoadScene(scenename, LoadSceneMode.Additive);
        }
    }

}