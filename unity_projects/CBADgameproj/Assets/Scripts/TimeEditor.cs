namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu]
    public class TimeEditor : ScriptableObject
    {
        // the name of timeline
        public string Name;

        public List<EnemyAppear> enemyinstance = new List<EnemyAppear>();
    }

    [System.Serializable]
    public class EnemyAppear
    {
        // the time of enemyappear
        public float time;

        //enemy data
        public GameObject enemy;
    }
}
