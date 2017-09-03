using UnityEngine;
using PhysicsAssignments.Object;

namespace PhysicsAssignments.Menu
{
    /// <summary>
    /// Handles input from user to set variables
    /// </summary>
    public class InputController : MonoBehaviour
    {
        #region Object fields

        //Object
        Ball m_Ball;

        //Preset vars
        float m_StartXVel = 0.0f;
        float m_StartYVel = 0.0f;
        float m_StartMass = 10.0f;
        float m_StartHeight = 8.0f;

        //Simulation vars
        bool m_Active = false;

        #endregion

        void Awake()
        {
            m_Ball = FindObjectOfType<Ball>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) StartSimulation();
            else if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        }

        public void SetBallStartHeight(float value)
        {
            Vector3 pos = m_Ball.transform.position;
            m_StartHeight = pos.y = 1f + 15.0f * value;
            if (m_Active) return;

            m_Ball.transform.position = pos;
        }

        public void SetBallMass(float value)
        {
            m_StartMass = 15f * value;
            if (m_StartMass <= 0.0f) m_StartMass = 0.1f;
            if (m_Active) return;

            m_Ball.SetMass(m_StartMass);
        }

        public void SetBallStartXVel(float value)
        {
            m_StartXVel = value * 0.2f;
            if (m_Active) return;

            m_Ball.SetStartVelo(new Vector3(m_StartXVel, m_StartYVel));
        }

        public void SetBallStartYVel(float value)
        {
            m_StartYVel = value * 0.2f;
            if (m_Active) return;

            m_Ball.SetStartVelo(new Vector3(m_StartXVel, m_StartYVel));
        }

        public void StartSimulation()
        {
            m_Active = true;
            m_Ball.Activate();
        }

        public void Reset()
        {
            if (!m_Active) return;

            m_Ball.SetStartVelo(new Vector3(m_StartXVel, m_StartYVel));
            m_Ball.SetMass(m_StartMass);
            Vector3 pos = m_Ball.transform.position;
            pos.y = m_StartHeight;
            m_Ball.transform.position = pos;

            m_Active = false;
            m_Ball.Reset();
        }
    }
}
