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

        #endregion

        void Start()
        {
            m_resetPos = transform.position;
            m_ground = GetComponent<SpriteRenderer>().bounds.size.x/2 + 0.5f;
            m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
        }

        void FixedUpdate()
        {
            //if (transform.position.y > m_ground)
            //{
            //    m_body.Velocity += Constants.GRAVITY * Time.fixedDeltaTime;
            //    m_hitGround = false;
            //}


            //if (transform.position.y < m_ground && !m_hitGround)
            //{
            //    m_body.Velocity = new Vector3(m_body.Velocity.x * 0.5f, m_body.Velocity.y * -0.5f);
            //    m_hitGround = true;

            //    if (m_body.Velocity.magnitude < 0.01f)
            //    {
            //        m_body.Velocity = Vector3.zero;
            //        transform.position = new Vector3(transform.position.x, m_ground);
            //    }
            //}

            m_body.Velocity += m_body.Acceleration*Time.fixedDeltaTime;
            transform.position += m_body.Velocity * Time.fixedDeltaTime;
            m_body.Acceleration *= 0.6f;
            m_body.Velocity *= 0.95f;
        }

        public void AddForce(Vector3 force)
        {
            m_body.Velocity += force;
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

        public void SetStartVelo(Vector3 v)
        {
            m_body.Velocity = v;
            m_startVelo = v;
        }

        public void AddAcceleration(Vector3 a)
        {
            m_body.Acceleration += a * 100 / m_Mass; 
        }
    }
}
