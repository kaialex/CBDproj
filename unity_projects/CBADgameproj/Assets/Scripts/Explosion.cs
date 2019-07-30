namespace CBADproj
{
    using UnityEngine;

    public class Explosion : MonoBehaviour
    {
        public GameObject explosionprehab;

        /// <summary>
        /// Play the explosionanim.
        /// </summary>
        /// <param name="position">Position.</param>
        public void Play_explosionanim(Vector3 position)
        {
            GameObject explosion = Instantiate(explosionprehab, new Vector3(position.x, position.y, -1.0f), Quaternion.identity);
            Destroy(explosion, 1);
        }
    }
}