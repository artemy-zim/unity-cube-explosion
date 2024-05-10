using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void DoExplosionForce()
    {
        _rigidbody.AddExplosionForce(_force, transform.position, _radius);
    }

    private void DoExplosionForce(Vector3 explosionPosition, float scale) 
    {
        float distance = (explosionPosition - transform.position).magnitude;

        float force = _force / distance / scale;
        float radius = _radius / scale;

        _rigidbody.AddExplosionForce(force, explosionPosition, radius);
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach(Collider collider in colliders) 
        {
            if(collider.TryGetComponent(out Explosion explosion))
            {
                if(explosion != this) 
                    explosion.DoExplosionForce(transform.position, transform.localScale.magnitude);
            }
        }
    }
}
