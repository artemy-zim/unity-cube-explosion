using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]
public class Cube : MonoBehaviour, IClickable, ISpawnable
{
    [SerializeField] private Spawner _spawner;

    private float _splitChance = 100f;

    public void OnClick()
    {
        if (CanSplit())
            _spawner.TrySpawn(gameObject);

        Destroy(gameObject);
    }

    public void OnSpawn()
    {
        int scaleReducer = 2;

        transform.localScale /= scaleReducer;
        transform.GetComponent<Renderer>().material.color = Random.ColorHSV();
        transform.GetComponent<Rigidbody>().useGravity = true;
    }

    private bool CanSplit()
    {
        float maxPercentage = 101f;
        int chanceReducer = 2;

        if(Random.Range(0, maxPercentage) <= _splitChance)
        {
            _splitChance /= chanceReducer;
            return true;
        }

        return false;
    }
}
