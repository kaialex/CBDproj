namespace CBADproj
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class Scoretext : MonoBehaviour
    {
        public Text resulttext;
        public int score;

        public void Start()
        {
            score = GameObject.Find("GameManager").GetComponent<Scoredata>().score;
            resulttext.text = "Score :" + score;
            SceneManager.UnloadSceneAsync("GameScene");
        }
    }
}