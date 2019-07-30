namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;

    public class Playershot : MonoBehaviour
    {
        public Bullet shotbullet;
        private List<Bullet> _shotbullets;
        public List<Bullet> Shotbullets { get { return _shotbullets; } }
        public Player player;
        public int shotframe;
        public float bulletspeed;
        private int timeframe = 0;
        private Vector3 suplementedposition = new Vector3(0, 0.3f, 0);

        public void FixedUpdate()
        {
            if (shotbullet.Bulletsmaker == BulletCriteria.Bulletsmaker.playerbullet)
            {
                if (timeframe == shotframe)
                {
                    if (player.hp > 0)
                    {
                        Instantiate(shotbullet, this.transform.position + suplementedposition, Quaternion.identity);
                        timeframe = 0;
                    }
                }
                foreach (Bullet bullet in GetPlayerBullets())
                {
                    bullet.transform.Translate(0.0f,bulletspeed * Time.deltaTime,0.0f);
                }

            }
            else
            {
                Debug.LogAssertion("player's bullet hasn't correct bulletsmaker");
            }

            timeframe += 1;
        }

        /// <summary>
        /// Gets the player bullets.
        /// </summary>
        /// <returns>The player bullets.</returns>
        public List<Bullet> GetPlayerBullets()
        {
            _shotbullets = FindObjectsOfType<Bullet>().ToList();
            return _shotbullets.Where(t => t.Bulletsmaker == BulletCriteria.Bulletsmaker.playerbullet).ToList();
        }
    }

}