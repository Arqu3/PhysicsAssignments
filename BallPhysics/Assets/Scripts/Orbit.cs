using PhysicsAssignments;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    [SerializeField] private Planet m_source1; //Earth 
    [SerializeField] private Planet m_source2; //Moon

    private float m_dist;

    private readonly float g = 9.82f;

    void Start()
    {
        m_source1.SetMass(81f);
        m_source2.SetMass(1f);
        m_source2.AddForce(new Vector3(0,1,0));
    }

    void Update()
    {
        var dir = m_source1.transform.position - m_source2.transform.position;
        dir.Normalize();
        m_dist = Vector3.Distance(m_source1.transform.position, m_source2.transform.position);
        var F1 = -(dir*g * m_source2.GetMass() * m_source1.GetMass()) / (m_dist * m_dist);
        var F2 = (-dir*g * m_source1.GetMass() * m_source2.GetMass()) / (m_dist * m_dist);

        m_source2.AddForce(F1);
        m_source1.AddForce(F2);
    }
}
