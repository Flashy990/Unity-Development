using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest01 : MonoBehaviour
{
    public int maxRayDistance = 100;
    // to manage which layers the ray should interact with
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // construct a new ray
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInformation;
        // see if the ray hit something or not
        if (Physics.Raycast(ray, out hitInformation, maxRayDistance, mask, QueryTriggerInteraction.Ignore))
        {
            print(hitInformation.collider.gameObject.name);
            Destroy(hitInformation.collider.gameObject);
            // to vizualize rays in the editor
            Debug.DrawLine(ray.origin, hitInformation.point, Color.red);
        }
        else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxRayDistance, Color.green);
        }
    }
}
