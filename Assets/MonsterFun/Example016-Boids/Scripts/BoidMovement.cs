using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMovement : MonoBehaviour {

        // the radius of a neighbourhood.
        public float neighbourRadius = 0.5f;
        
        // size of boundary area.
        public float boardSize = 5.0f;
        
        // an upper bound on the speed of boid movement
        public float speed = 1.0f;
        
        // internal variables needed for kinematic simulation.
        private Vector3 velocity;
        
        void Start () {
          velocity = new Vector3 (0,0,0);
        }
        
	// Update is called once per frame
	void Update () {
	  Collider [] listOfNeighbours = findNeighbours (neighbourRadius);
	  Vector3 targetDirection = calculateDirection (listOfNeighbours, 0.45f, 0.4f, 0.2f);
	  Vector3 moveDirection = checkBounds (targetDirection, boardSize);
	  moveOneStep (moveDirection, speed);
	}
	
	// Return the list of neighbours within a particular 
	// distance of the current object. Only objects on layer 9 
	// are selected.
	Collider [] findNeighbours (float radius)
	{
          Collider [] hitColliders = Physics.OverlapSphere (this.transform.position, radius, 1 << 9);
	  return hitColliders;
	}
	
	// Use the boids direction calculation based on the
	// given neighbour's positions.
	Vector3 calculateDirection (Collider [] neighbours, float separation, float convergenceFactor, float alignmentFactor)
	{
          Vector3 averagePosition = findAveragePosition (neighbours);
          Vector3 averageDirection = findAverageDirection (neighbours);
          Vector3 directionToAveragePosition = averagePosition - this.transform.position;
          if (directionToAveragePosition.magnitude < separation)
          {
            // we're too close - change direction to away from the center.
            directionToAveragePosition = -directionToAveragePosition;
          }
          directionToAveragePosition = directionToAveragePosition.normalized;
          Vector3 direction = directionToAveragePosition * convergenceFactor + averageDirection * alignmentFactor;
          
	  return direction;
	}
	
	// Find the average position of the objects in the list of neighbours.
	Vector3 findAveragePosition (Collider [] neighbours)
	{
	  Vector3 averagePosition = new Vector3 (0,0,0);
	  // add each element.
	  for (int i = 0; i < neighbours.Length; i++)
	  {
	    averagePosition = averagePosition + neighbours[i].gameObject.transform.position;
	  }
	  // divide by the number of elements.
	  averagePosition = (1.0f / neighbours.Length) * averagePosition;
	  return averagePosition;
	}
	
	// Find the average direction of the objects in the list of neighbours.
	// Returns a normalized vector, unless the average direction is a zero vector.
	Vector3 findAverageDirection (Collider [] neighbours)
	{
	  Vector3 averageDirection = new Vector3 (0,0,0);
	  // add each element.
	  for (int i = 0; i < neighbours.Length; i++)
	  {
	    averageDirection = averageDirection + neighbours[i].gameObject.transform.forward;
	  }
	  // divide by the number of elements.
	  averageDirection = (1.0f / neighbours.Length) * averageDirection;
	  // normalize
	  if (averageDirection.magnitude != 0.0f)
	  {
	    averageDirection = averageDirection.normalized;
	  }
	  return averageDirection;
	}
	
	void enforceLimit (ref Vector3 direction, ref Vector3 velocity, float limit, Vector3 axis)
	{
	  if (Vector3.Dot (this.transform.position, axis) > limit)
	  {
	    direction += -2.0f * Mathf.Abs (Vector3.Dot (direction, axis)) * axis; 
	    velocity += -2.0f * Mathf.Abs (Vector3.Dot (velocity, axis)) * axis; 
	  }
	}
	
	// Ensure that a movement in the given direction
	// does not take the object beyonds the bounds of the
	// movement area.
	Vector3 checkBounds (Vector3 direction, float limit)
	{
	  // very small perturbation to break any ties.
	  direction = direction + new Vector3 (Random.Range (-0.01f,0.01f), Random.Range (-0.01f,0.01f), 0);
	  // remove any z-component.
	  direction.z = 0;
	  
	  enforceLimit (ref direction, ref velocity, limit, new Vector3 (1,0,0));
	  enforceLimit (ref direction, ref velocity, limit, new Vector3 (-1,0,0));
	  enforceLimit (ref direction, ref velocity, limit, new Vector3 (0,1,0));
	  enforceLimit (ref direction, ref velocity, limit, new Vector3 (0,-1,0));
          return direction;
	}
	
	// Take a step in the given direction at a particular
	// speed.
	void moveOneStep (Vector3 direction, float speed)
	{
	  Vector3 acceleration = direction;
	  velocity = velocity + acceleration * Time.deltaTime;
	  // some viscosity.
	  velocity = (1.0f - (0.2f * Time.deltaTime)) * velocity;
	  if (velocity.magnitude > speed)
	  {
	    velocity = speed * velocity.normalized;
	  }
          this.transform.position = this.transform.position + velocity * Time.deltaTime;
          this.transform.forward = velocity;
	}
}
