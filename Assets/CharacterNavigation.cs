using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class CharacterNavigation : MonoBehaviour
{
	public NavMeshAgent agent;
    public Vector3 target;
    public Transform targetGO;

    public ThirdPersonCharacter character;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        //agent.updatePosition = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetGO.position);
        //if(targe)

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
