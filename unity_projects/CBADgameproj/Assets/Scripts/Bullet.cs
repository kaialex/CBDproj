namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletCriteria.Bulletsmaker _bulletsmaker;
        public BulletCriteria.Bulletsmaker Bulletsmaker { get { return _bulletsmaker; } }

        [SerializeField]
        private BulletCriteria.Bulletstype _bulletstype;
        public BulletCriteria.Bulletstype Bulletstype { get { return _bulletstype; } }

        private Vector3 _bulletposition;
        public Vector3 Bulletposition { get { return _bulletposition; } }

        public Vector3 directionvector;

        public void Update()
        {
            //destroy the bullet out of screen
            _bulletposition = this.transform.position;
            if (Mathf.Abs(_bulletposition.y) > 6.0f || Mathf.Abs(_bulletposition.x) > 3.5f )
            {
                Destroy(this.gameObject);
            }
        }

        public void FixedUpdate()
        {
            if (this._bulletstype == BulletCriteria.Bulletstype.straight)
            {
                Straightbullet(directionvector);
            }
        }

        /// <summary>
        /// the movement of straightbulet
        /// </summary>
        /// <param name="directionvector">Directionvector.</param>
        public void Straightbullet(Vector3 directionvector)
        {
            this.gameObject.transform.Translate(directionvector * Time.deltaTime);
        }
    }
}