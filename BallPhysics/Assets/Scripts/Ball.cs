using UnityEngine;
using PhysicsAssignments.Constants;

namespace PhysicsAssignments.Object
{
    public class Ball : MonoBehaviour
    {
        #region Private exposed fields

        [Header("Mass (KG)")]
        [Range(0.0f, 10000.0f)]
        [SerializeField]
        float m_Mass = 10.0f;

        #endregion

        #region Private fields

        //Position & velocity
        Vector2 m_Position;
        Vector3 m_Velocity;

        #endregion

        void FixedUpdate()
        {
            if (transform.position.y < 0.0f) m_Velocity *= -0.5f;
            else m_Velocity += m_Mass * Constants.Constants.GRAVITY / 100.0f * Time.fixedDeltaTime;

            transform.position += m_Velocity;
        }
    }
}
