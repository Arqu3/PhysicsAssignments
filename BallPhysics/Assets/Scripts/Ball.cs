using UnityEditor;
using UnityEngine;

namespace PhysicsAssignments.Object
{
    public class Ball : MonoBehaviour
    {
        #region Private exposed fields

        [Header("Mass (KG)")]
        [Range(0.0f, 15.0f)]
        [SerializeField]
        float m_Mass = 10.0f;

        #endregion

        #region Private fields

        private Vector3 m_resetPos;

        private bool m_hitGround = false;
        private bool m_active = false;

        private float m_ground;

        private Body m_body;

        #endregion

        void Start()
        {
            m_resetPos = transform.position;
            m_ground = GetComponent<SpriteRenderer>().bounds.size.x/2 + 0.5f;
            m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
        }

        void FixedUpdate()
        {
            //if (!m_active)
            //    return;

            if (transform.position.y > m_ground)
            {
                m_body.Velocity += m_Mass*Constants.GRAVITY/100.0f*Time.fixedDeltaTime;
                m_hitGround = false;
            }
                

            if (transform.position.y < m_ground && !m_hitGround)
            {
                m_body.Velocity *= -0.5f;
                m_hitGround = true;

                if (m_body.Velocity.magnitude < 0.01f)
                {
                    m_body.Velocity = Vector3.zero;
                    transform.position = new Vector3(transform.position.x, m_ground);
                }
            }

            transform.position += m_body.Velocity;
        }

        public void Activate()
        {
            m_active = true;
            m_resetPos = transform.position;
        }

        public void Reset()
        {
            transform.position = m_resetPos;
            m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
            m_active = false;
        }
    }
}
