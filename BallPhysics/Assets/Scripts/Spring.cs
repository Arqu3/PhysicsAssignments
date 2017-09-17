using PhysicsAssignments.Object;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]private Ball[] m_balls = new Ball[2];

    private const float m_distance = 3f;

    void FixedUpdate()
    {
        var x = Vector2.Distance(m_balls[0].transform.position, m_balls[1].transform.position);

        print("Current dist: " + x);

        var p1 = m_balls[0].transform.position - m_balls[1].transform.position;
        p1.Normalize();
        var p2 = m_balls[1].transform.position - m_balls[0].transform.position;
        p2.Normalize();
        var force1 = -1 * (x - m_distance) * (p1 / x);
        var force2 = -1 * (x - m_distance) * (p2 / x);

        if (x < m_distance)
        {
            //m_balls[0].AddAcceleration(-force1);
            //m_balls[1].AddAcceleration(-force2);
            return;
        }
            

        m_balls[0].AddAcceleration(force1);
        m_balls[1].AddAcceleration(force2);
    }
}
