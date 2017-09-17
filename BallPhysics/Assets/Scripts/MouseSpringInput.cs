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
        float m_ForceMulti = 0.1f;
        Ball m_SelectedBall = null;

        #endregion

        void Awake()
        {
            m_Balls = FindObjectsOfType<Ball>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

            if (Input.GetMouseButton(1))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0.0f;
                if (!m_SelectedBall)
                {
                    float selectDist = Mathf.Infinity;
                    foreach (Ball ball in m_Balls)
                    {
                        Vector3 pos = ball.transform.position;
                        pos.z = 0.0f;

                        float dist = Vector3.Distance(pos, mousePos);
                        if (dist < selectDist)
                        {
                            m_SelectedBall = ball;
                            selectDist = dist;
                        }
                    }
                }

                m_SelectedBall.AddForce((mousePos - m_SelectedBall.transform.position).normalized * m_ForceMulti);
            }
            else m_SelectedBall = null;
        }

        public void SetForceMulti(float multi)
        {
            m_ForceMulti = multi;
        }

        public void ToggleGravity()
        {
            foreach(Ball ball in m_Balls)
            {
                ball.ToggleGravity();
            }
        }
    }
}
