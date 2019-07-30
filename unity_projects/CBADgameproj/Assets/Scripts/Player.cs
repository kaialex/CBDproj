namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Player : MonoBehaviour 
    {
        public Movescene movescene;
        public Explosion explosion;
        public GameObject hpUI;
        private List<GameObject> hpimage;

        public float speed = 2f;
        public int hp = 5;

        [SerializeField]
        private Accelarationinput accelarationinput;

        private Vector3 playerposition;

        private void Start()
        {
            hpimage = GetChildren(hpUI);
        }

        public void FixedUpdate()
        {
            //the movement of player in smartphone
            this.gameObject.transform.Translate(accelarationinput.GetAccel * speed * Time.deltaTime, 0, 0);
            //the movement of player in computer
            this.gameObject.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

            playerposition = this.transform.position;
            if (playerposition.x > 2.5f)
            {
                playerposition.x = 2.5f;
                this.transform.position = playerposition;
            }
            else if (playerposition.x < -2.5f)
            {
                playerposition.x = -2.5f;
                this.transform.position = playerposition;
            }
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <returns>The children.</returns>
        /// <param name="parent">Parent.</param>
        public List<GameObject> GetChildren(GameObject parent)
        {
            List<GameObject> child = new List<GameObject>();
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                child.Add(parent.transform.GetChild(i).gameObject);
            }
            return child;
        }

        public void UpdateHp()
        {
            Destroy(hpimage[hp]);
        }

        public void MovetoGameover()
        {
            movescene.MoveSceneadditive("GameoverScene");
        }

        /// <summary>
        /// collision.
        /// </summary>
        /// <param name="collision">Collision.</param>
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "bullet")
            {
                if (collision.gameObject.GetComponent<Bullet>().Bulletsmaker == BulletCriteria.Bulletsmaker.enemybullet)
                {
                    Destroy(collision.gameObject);
                    hp -= 1;
                    if (hp == 0)
                    {
                        UpdateHp();
                        explosion.Play_explosionanim(this.transform.position);
                        this.GetComponent<SpriteRenderer>().enabled = false;
                        Invoke("MovetoGameover", 1);
                    } else if (hp > 0)
                    {
                        UpdateHp();
                    }
                }
            }
        }
    }
}
