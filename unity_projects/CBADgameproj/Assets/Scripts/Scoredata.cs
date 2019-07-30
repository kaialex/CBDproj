namespace CBADproj
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Scoredata : MonoBehaviour
    {
        public Text scoretext;
        public int score = 0;

        public void Start()
        {
            score = 0;
            ScoreUpdate();
        }

        public void GetScore(int getscore)
        {
            score += getscore;
            ScoreUpdate();
        }

        public void ScoreUpdate()
        {
            scoretext.text = "" + score;
        }
    }
}