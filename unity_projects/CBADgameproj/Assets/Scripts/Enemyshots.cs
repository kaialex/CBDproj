namespace CBADproj
{
    using UnityEngine;

    public class Enemyshots : MonoBehaviour
    {

        private Bullet shottedbullet;
        private const float PI = Mathf.PI;

        public void ShotManager(Enemydata enemydata, int i, GameObject enemyself)
        {
            switch (enemydata.shotdata[i].shottype)
            {
                case BulletCriteria.Shottype.linearshot:
                    Linearshot(enemydata,i,enemyself);
                    break;
                case BulletCriteria.Shottype.trailshot:
                    Trailshot(enemydata, i, enemyself);
                    break;
                case BulletCriteria.Shottype.roundshot:
                    Roundshot(enemydata, i, enemyself);
                    break;
                case BulletCriteria.Shottype.self_targeted:
                    Self_targeted(enemydata, i, enemyself);
                    break;
            }
        }

        /// <summary>
        /// shot the bullet linear.
        /// </summary>
        /// <param name="enemydata">Enemydata.</param>
        /// <param name="i">The index.</param>
        /// <param name="enemyself">Enemyself.</param>
        public void Linearshot(Enemydata enemydata, int i, GameObject enemyself)
        {
            shottedbullet = Instantiate(enemydata.shotdata[i].bullet,enemyself.transform.position, Quaternion.identity);
            shottedbullet.directionvector = new Vector3(1.0f * Mathf.Sin(Degtorad(enemydata.shotdata[i].directiondegree)), -1.0f * Mathf.Cos(Degtorad(enemydata.shotdata[i].directiondegree)), 0.0f).normalized * enemydata.shotdata[i].bulletspeed;
        }

        /// <summary>
        /// shot the bullet to 3 directions.
        /// </summary>
        /// <param name="enemydata">Enemydata.</param>
        /// <param name="i">The index.</param>
        /// <param name="enemyself">Enemyself.</param>
        public void Trailshot(Enemydata enemydata, int i, GameObject enemyself)
        {
            for (int j = -1; j <= 1; j++)
            {
                shottedbullet = Instantiate(enemydata.shotdata[i].bullet, enemyself.transform.position, Quaternion.identity);
                if (enemydata.shotdata[i].resolution == 0) enemydata.shotdata[i].resolution = 16;
                shottedbullet.directionvector = new Vector3(1.0f * Mathf.Sin(Degtorad(enemydata.shotdata[i].directiondegree + 360 / enemydata.shotdata[i].resolution * j)), -1.0f * Mathf.Cos(Degtorad(enemydata.shotdata[i].directiondegree + 360 / enemydata.shotdata[i].resolution * j)), 0.0f).normalized * enemydata.shotdata[i].bulletspeed;
            }
        }

        /// <summary>
        /// shot the bullet rouder.
        /// </summary>
        /// <param name="enemydata">Enemydata.</param>
        /// <param name="i">The index.</param>
        /// <param name="enemyself">Enemyself.</param>
        public void Roundshot(Enemydata enemydata, int i, GameObject enemyself)
        {
            for (int j = 0; j < (enemydata.shotdata[i].resolution); j++)
            {
                shottedbullet = Instantiate(enemydata.shotdata[i].bullet, enemyself.transform.position, Quaternion.identity);
                if (enemydata.shotdata[i].resolution == 0) enemydata.shotdata[i].resolution = 16;
                shottedbullet.directionvector = new Vector3(1.0f * Mathf.Sin(Degtorad(enemydata.shotdata[i].directiondegree + 360 * j / enemydata.shotdata[i].resolution)), -1.0f * Mathf.Cos(Degtorad(enemydata.shotdata[i].directiondegree + 360 * j / enemydata.shotdata[i].resolution)), 0.0f).normalized * enemydata.shotdata[i].bulletspeed;
            }
        }

        /// <summary>
        /// shot the bullet to player.
        /// </summary>
        /// <param name="enemydata">Enemydata.</param>
        /// <param name="i">The index.</param>
        /// <param name="enemyself">Enemyself.</param>
        public void Self_targeted(Enemydata enemydata, int i, GameObject enemyself)
        {   
            shottedbullet = Instantiate(enemydata.shotdata[i].bullet, enemyself.transform.position, Quaternion.identity);
            Vector3 diff_pos = GameObject.FindGameObjectWithTag("Player").transform.position - enemyself.transform.position;
            shottedbullet.directionvector = new Vector3(diff_pos.x, diff_pos.y, 0.0f).normalized * enemydata.shotdata[i].bulletspeed;
        }

        public float Degtorad(float deg) => 2 * PI * deg / 360;
    }
}