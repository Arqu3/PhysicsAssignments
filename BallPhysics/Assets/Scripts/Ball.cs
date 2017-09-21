using System.Linq.Expressions;
using UnityEngine;

namespace PhysicsAssignments.Object
{
    public class Ball : MonoBehaviour
    {
        #region Private exposed fields

        [Header("Mass (KG)")]
        //[Range(0.0f, 15.0f)]
        [SerializeField]
        float m_Mass = 10.0f;

        #endregion

        #region Private fields

        private Vector3 m_resetPos;
        private Vector3 m_startVelo;

        private bool m_hitGround = false;
        private bool m_active = false;

        private float m_ground;

        private Body m_body;

        private bool m_gravity = false;

        #endregion

        void Start()
        {
            m_resetPos = transform.position;
            m_ground = GetComponent<SpriteRenderer>().bounds.size.x/2 + 0.5f;
            m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
        }

        void FixedUpdate()
        {
            transform.position += m_body.Velocity * Time.fixedDeltaTime;

            if (m_gravity)
            {
                if (transform.position.y > m_ground)
                {
                    m_body.Velocity += Constants.GRAVITY*Time.fixedDeltaTime;
                    m_hitGround = false;
                    m_body.Velocity += m_body.Acceleration*Time.fixedDeltaTime;
                }


                if (transform.position.y < m_ground && !m_hitGround)
                {
                    m_body.Velocity = new Vector3(m_body.Velocity.x*0.5f, m_body.Velocity.y*-0.5f);
                    m_hitGround = true;

                    if (m_body.Velocity.magnitude < 0.01f)
                    {
                        m_body.Velocity = Vector3.zero;
                        transform.position = new Vector3(transform.position.x, m_ground);

                        m_body.Velocity += m_body.Acceleration*Time.fixedDeltaTime;
                    }
                }
            }
            else
            {
                m_body.Velocity += m_body.Acceleration * Time.fixedDeltaTime;
            }

            m_body.Acceleration *= 0.6f;
            m_body.Velocity *= 0.95f;
        }

        public void AddForce(Vector3 force)
        {
            m_body.Velocity += force*1000 / m_Mass * Time.deltaTime;
        }

        public void Activate()
        {
            if (m_active)
                return;

            m_active = true;
            m_resetPos = transform.position;
        }

        public void Reset()
        {
            transform.position = m_resetPos;
            m_body = new Body(transform.position, m_startVelo, Vector3.zero);
            m_active = false;
        }

        public void SetMass(float m)
        {
            m_Mass = m;
        }

        public Vector3 getVelo()
        {
            return m_body.Velocity;
        }

        public void ToggleGravity()
        {
            m_gravity = !m_gravity;
        }

        public void SetStartVelo(Vector3 v)
        {
            m_body.Velocity = v;
            m_startVelo = v;
        }

        public void AddSpringForce(Vector3 f)
        {
            m_body.Velocity += f * 100 / m_Mass * Time.deltaTime; 
        }
    }
}
