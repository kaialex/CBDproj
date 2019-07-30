namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Accelarationinput : MonoBehaviour
    {
        private float accelaration_x;
        public float GetAccel
        {
            get
            {
                return accelaration_x;
            }
        }

        public void Update()
        {
            accelaration_x = Input.acceleration.x;
            if (Mathf.Abs(accelaration_x) < 0.1)
            {
                accelaration_x = 0.0f;
            }
            else if (accelaration_x > 0.7)
            {
                accelaration_x = 0.7f;
            }
            else if (accelaration_x < -0.7)
            {
                accelaration_x = -0.7f;
            }
        }
    }
}