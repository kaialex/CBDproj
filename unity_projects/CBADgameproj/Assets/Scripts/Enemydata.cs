namespace CBADproj
{
    using UnityEngine;
    //using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;

    [CreateAssetMenu]
    public class Enemydata : ScriptableObject
    {
        //enemy Hp
        public int Hp;

        //enemy name
        public string Name;

        //enemy score when defeated
        public int defeatscore;

        //destroy or not when the enemy animation finished
        public bool isloop;

        public List<MoveData> movedata = new List<MoveData>();
        public List<ShotData> shotdata = new List<ShotData>();
    }

    [System.Serializable]
    public class ShotData
    {
        //shot time
        public float shottime;

        //shot type
        public BulletCriteria.Shottype shottype;

        //shot bullet data
        public Bullet bullet;

        //bullet speed
        public float bulletspeed;

        //the direction to shot the bullet
        public float directiondegree;

        //how many shot divide
        public int resolution; 
    }

    [System.Serializable]
    public class MoveData
    {
        //keyframe time
        public float time;

        //keyframe position
        public Vector3 position;

        //how move the enemy
        public EnemyCriteria.Movemethod movemethod;
    }
}
