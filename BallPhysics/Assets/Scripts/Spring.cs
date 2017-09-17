using PhysicsAssignments.Object;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]private Ball[] m_balls = new Ball[2];

    private float m_distance = 1f;

    public float k = -1f;

    void Start()
    {
        m_distance = Vector2.Distance(m_balls [0].transform.position, m_balls [1].transform.position);
    }

    void FixedUpdate()
    {
        k = -1f;
        var x = Vector2.Distance(m_balls[0].transform.position, m_balls[1].transform.position);

        

        if (x < m_distance)
        {
            return;
        }

        var p1 = m_balls[0].transform.position - m_balls[1].transform.position;
        p1.Normalize();
        var p2 = m_balls[1].transform.position - m_balls[0].transform.position;
        p2.Normalize();
        var force1 = -k * (x - m_distance) * (p2 / x) - 0.01f * (m_balls[0].getVelo() - m_balls[1].getVelo());
        var force2 = -k * (x - m_distance) * (p1 / x) - 0.01f * (m_balls[1].getVelo() - m_balls[0].getVelo());
        m_balls[0].AddAcceleration(force1 / Time.fixedDeltaTime);
        m_balls[1].AddAcceleration(force2 / Time.fixedDeltaTime);
    }
}
