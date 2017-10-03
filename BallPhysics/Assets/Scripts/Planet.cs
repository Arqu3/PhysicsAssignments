using PhysicsAssignments;
using UnityEngine;

public class Planet : MonoBehaviour {

    private Vector3 m_startVelo;

    private Body m_body;
    
    private bool m_gravity = false;

    [SerializeField]
    Planet m_GravitationalSource;

    [SerializeField]
    bool m_Moon = false;

    void Awake () {
        m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
    }
	
	void FixedUpdate () {
        Vector3 diff = m_GravitationalSource.transform.position - transform.position;
        Vector3 dir = diff.normalized;
        float force = ( m_GravitationalSource.GetMass () * GetMass () * -9.82f ) / diff.sqrMagnitude;
        AddForce (dir * force);

        if (m_Moon)
        {
            AddForce (Quaternion.AngleAxis (90.0f, Vector3.up) * dir * 100f);
        }

        transform.position += m_body.Velocity * Time.fixedDeltaTime;
        m_body.Velocity *= 0.9f;
    }

    public void SetMass(float m)
    {
        m_body.Mass = m;
    }

    public float GetMass()
    {
        return m_body.Mass;
    }

    public void AddForce(Vector3 f)
    {
        m_body.Velocity += f / m_body.Mass * Time.deltaTime;
    }
}
