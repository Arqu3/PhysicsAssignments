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

        //Preset variables
        float m_StartMass = 0.0f;

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
            pos.y = 1f + 15.0f * value;
            m_Ball.transform.position = pos;
        }

        public void SetBallMass(float value)
        {

        }

        public void StartSimulation()
        {
            m_Ball.Activate();
        }

        public void Reset()
        {
            m_Ball.Reset();
        }
    }
}
