using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;

public class Burst : MonoBehaviour
{
    // public ParticleSystem.Particle ps;
    public Object burstPrefab;
    public InputActionReference trigger;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ps = GetComponent<ParticleSystem.Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        trigger.action.started += Space;
    }
    
    void OnDisable()
    {
        trigger.action.started -= Space; // To avoid and action like 'Space' being squiggled, create a method of the same name down below.
    }

    private void Space(InputAction.CallbackContext context) // A method of the Action you created is needed down here. 
    {
        Debug.Log("Space");
        Instantiate(burstPrefab);
    }
}
