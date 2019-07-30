namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;

    public class AnimationEventMaker : MonoBehaviour
    {
        public List<Enemydata> wholeenemydata;
        private AnimationClip enemyanim;

        private AnimationCurve curve_x;
        private AnimationCurve curve_y;
        private AnimationCurve curve_z;

        /// <summary>
        /// Makes the animation.
        /// </summary>
        /// <param name="enemydata">Enemydata.</param>
        public AnimationClip MakeAnimation(Enemydata enemydata, ref AnimationClip enemyanim)
        {
            enemyanim.name = enemydata.name;
            enemyanim.legacy = true;
            curve_x = new AnimationCurve();
            curve_y = new AnimationCurve();
            curve_z = new AnimationCurve();
            for (int i = 0; i < enemydata.movedata.Count; i++)
            {
                MoveData movedata = enemydata.movedata[i];
                Keyframe pos_x = new Keyframe(movedata.time, movedata.position.x);
                Keyframe pos_y = new Keyframe(movedata.time, movedata.position.y);
                Keyframe pos_z = new Keyframe(movedata.time, movedata.position.z);
                curve_x.AddKey(pos_x);
                curve_y.AddKey(pos_y);
                curve_z.AddKey(pos_z);
            }

            enemyanim.SetCurve("", typeof(Transform), "localPosition.x", curve_x);
            enemyanim.SetCurve("", typeof(Transform), "localPosition.y", curve_y);
            enemyanim.SetCurve("", typeof(Transform), "localPosition.z", curve_z);
            MakeAnimationEvent(enemydata, enemyanim);
            return enemyanim;
        }

        /// <summary>
        /// Makes the animation event.
        /// </summary>
        /// <param name="enemydata">Enemydata.</param>
        public void MakeAnimationEvent(Enemydata enemydata, AnimationClip enemyanim)
        {
            for (int i = 0; i < enemydata.shotdata.Count; i++)
            {
                AnimationEvent evt = new AnimationEvent();
                if (enemydata.shotdata[i].shottime <= enemyanim.length)
                {
                    evt.time = enemydata.shotdata[i].shottime;
                    evt.intParameter = i;
                    evt.functionName = "SendEnemyshot";

                    enemyanim.AddEvent(evt);
                }
                else
                {
                    Debug.LogAssertion("shottimeの設定ががアニメーション時間をこえています");
                }
            }
            if (!enemydata.isloop)
            {
                AnimationEvent evt = new AnimationEvent();
                evt.time = enemyanim.length;
                evt.functionName = "Selfdestroy";

                enemyanim.AddEvent(evt);
            }
            else
            {
                AnimationEvent evt = new AnimationEvent();
                evt.time = enemyanim.length;
                evt.functionName = "Loop";

                enemyanim.AddEvent(evt);
            }
        }
    }
}