using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhysicsAssignments.Object;

namespace PhysicsAssignments.Menu
{
    public class MouseSpringInput : MonoBehaviour
    {
        #region Private fields

        Ball[] m_Balls;
        float m_ForceMulti = 1.0f;

        #endregion

        void Awake()
        {
            m_Balls = FindObjectsOfType<Ball>();
        }

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0.0f;
                Ball selectedBall = null;
                float selectDist = Mathf.Infinity;
                foreach(Ball ball in m_Balls)
                {
                    Vector3 pos = ball.transform.position;
                    pos.z = 0.0f;

                    float dist = Vector3.Distance(pos, mousePos);
                    if (dist < selectDist)
                    {
                        selectedBall = ball;
                        selectDist = dist;
                    }
                }

                selectedBall.AddForce((mousePos - selectedBall.transform.position).normalized * m_ForceMulti);
            }
        }

        public void SetForceMulti(float multi)
        {
            m_ForceMulti = multi;
        }
    }
}
