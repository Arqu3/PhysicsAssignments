using PhysicsAssignments;
using UnityEngine;

public class Planet : MonoBehaviour {

    private Vector3 m_startVelo;
    Vector3 m_Direction = Vector3.zero;

    private Body m_body;
    
    private bool m_gravity = true;

    [SerializeField]
    Planet m_GravitationalSource;
    [SerializeField]
    float m_Mass = 10.0f;

    [SerializeField]
    bool m_Moon = false;

    void Awake () {
        m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
        SetMass (m_Mass);
    }
	
	void FixedUpdate () {
        transform.position += m_body.Velocity * Time.fixedDeltaTime;
        m_body.Velocity *= 0.9f;

        Vector3 diff = m_GravitationalSource.transform.position - transform.position;
        if ( m_gravity ) m_Direction = diff.normalized;
        float force = ( m_GravitationalSource.GetMass () * GetMass () * -9.82f ) / diff.sqrMagnitude;

        if ( m_gravity ) AddForce (m_Direction * force);

        if ( m_Moon ) AddForce (Quaternion.AngleAxis (90.0f, Vector3.up) * m_Direction * 50.0f);
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

    public void ToggleGravity()
    {
        m_gravity = !m_gravity;
    }
}
