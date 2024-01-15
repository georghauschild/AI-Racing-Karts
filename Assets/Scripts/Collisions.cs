using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    public KartAgent kartAgent;
    public RaycastHit raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast unter dem Objekt
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit))
        {
            if (raycastHit.collider.gameObject.CompareTag("Gras"))
            {
              //  Debug.Log("Raycast hat Gras berührt");
                kartAgent.AddReward(-0.1f);
            }
            if (raycastHit.collider.gameObject.CompareTag("Road"))
            {
              //  Debug.Log("Raycast hat Road berührt");
              //  kartAgent.AddReward(0.1f);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Kollision mit einer Wand: Reward -0.3");
            kartAgent.AddReward(-0.3f);
        }
    }
}
