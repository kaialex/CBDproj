namespace CBADproj
{
    public class BulletCriteria
    {
        /// <summary>
        /// who shot the bullet.
        /// </summary>
        public enum Bulletsmaker
        {
            playerbullet = 0,
            enemybullet,
            num
        }

        /// <summary>
        /// the type of bullets.
        /// </summary>
        public enum Bulletstype
        {
            straight = 0,
            abnormal,
            num
        }

        /// <summary>
        /// the type of shots.
        /// </summary>
        public enum Shottype
        {
            linearshot = 0,
            trailshot,
            roundshot,
            self_targeted,
            num
        }
    }
}
