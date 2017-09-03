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
        float m_StartMass = 0.0f;

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
            if (m_Active) return;

            Vector3 pos = m_Ball.transform.position;
            pos.y = 1f + 15.0f * value;
            m_Ball.transform.position = pos;
        }

        public void SetBallMass(float value)
        {
            if (m_Active) return;

            m_Ball.SetMass(m_StartMass = 15f * value);
        }

        public void SetBallStartXVel(float value)
        {
            if (m_Active) return;

            m_Ball.SetStartVelo(new Vector3(m_StartXVel = value, m_StartYVel));
        }

        public void SetBallStartYVel(float value)
        {
            if (m_Active) return;

            m_Ball.SetStartVelo(new Vector3(m_StartXVel, m_StartYVel = value));
        }

        public void StartSimulation()
        {
            m_Active = true;
            m_Ball.Activate();
        }

        public void Reset()
        {
            m_Active = false;
            m_Ball.Reset();
        }
    }
}
