namespace CBADproj
{

    using UnityEngine;
    using System.Collections;

    public class EnemyCriteria : MonoBehaviour
    {
        public enum Movemethod
        {
            linearmove = 0,
            othermove,
            num
        }
        [SerializeField]
        public Enemydata enemydata;

        public Enemyshots enemyshots;
        public Explosion explosion;
        public AnimationEventMaker animationmaker;
        public Scoredata scoredata;

        private Animation animation;
        private AnimationClip enemy_animationclip;

        private int hp;

        private void Start()
        {
            //read the class
            ReadClass();

            hp = enemydata.Hp;

            //make animation
            MakeAnimation();
        }

        private void ReadClass()
        {
            GameObject gamemanager = GameObject.Find("GameManager");
            GameObject enemymanager = GameObject.Find("EnemyManager");
            enemyshots = enemymanager.GetComponent<Enemyshots>();
            explosion = enemymanager.GetComponent<Explosion>();
            animationmaker = gamemanager.GetComponent<AnimationEventMaker>();
            scoredata = gamemanager.GetComponent<Scoredata>();
        }

        /// <summary>
        /// Makes the enemy animation.
        /// </summary>
        public void MakeAnimation()
        {
            animation = this.GetComponent<Animation>();
            enemy_animationclip = new AnimationClip();
            animationmaker.MakeAnimation(enemydata, ref enemy_animationclip);
            animation.AddClip(enemy_animationclip,enemydata.name);
            animation.Play(enemydata.name);
        }

        public void Loop()
        {
            animation.Rewind(enemydata.name);
        }

        /// <summary>
        /// make enemyshot in animation.
        /// </summary>
        /// <param name="i">The index.</param>
        public void SendEnemyshot(int i)
        {
            enemyshots.ShotManager(enemydata, i, this.gameObject);
        }

        private void Enemydamaged(int point = 1)
        {
            this.hp -= point;
            if (this.hp <= 0)
            {
                scoredata.GetScore(enemydata.defeatscore);
                explosion.Play_explosionanim(this.gameObject.transform.position);
                Selfdestroy();
            }
        }

        public void Selfdestroy()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// Collision.
        /// </summary>
        /// <param name="collider">Collider.</param>
        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "bullet")
            {
                if (collider.gameObject.GetComponent<Bullet>().Bulletsmaker == BulletCriteria.Bulletsmaker.playerbullet)
                {
                    Enemydamaged();
                }
            }
        }
    }
}
