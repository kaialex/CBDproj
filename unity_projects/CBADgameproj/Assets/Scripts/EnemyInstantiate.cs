namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyInstantiate : MonoBehaviour
    {

        public TimeEditor timeeditor;
        public List<bool> enemyappeared;

        public void Start()
        {
            for (int i = 0; i < timeeditor.enemyinstance.Count; i++)
            {
                enemyappeared.Add(false);
            }
        }

        public void Update()
        {
            for (int i = 0; i < timeeditor.enemyinstance.Count; i++)
            {
                if ((Time.timeSinceLevelLoad > timeeditor.enemyinstance[i].time) && (!enemyappeared[i]))
                {
                    Instantiate(timeeditor.enemyinstance[i].enemy);
                    enemyappeared[i] = true;
                }
            }
        }
    }

}