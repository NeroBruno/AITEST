using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConnectedWaypoint : MonoBehaviour
{
    [SerializeField] protected float debugDrawRadius = 1.0f;

    [SerializeField] protected float _connectivityRadius = 5f;

    private List<ConnectedWaypoint> _connections;

    public void Start()
    {
        // Get all waypoint objects in scene
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        
        // Create list of waypoints I can refer
        _connections = new List<ConnectedWaypoint>();
        
        // Check if they are a connected waypoint
        for (int i = 0; i < allWaypoints.Length; i++)
        {
            ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>();
            
            // Found a waypoint
            if (nextWaypoint != null)
            {
                if (Vector3.Distance(transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this)
                {
                    _connections.Add(nextWaypoint);
                }
            }
        }
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
    }

    public ConnectedWaypoint NextWaypoint(ConnectedWaypoint previousWaypoint)
    {
        if (_connections.Count == 0)
        {
            Debug.LogError("No waypoints!!");
            return null;
        }
        else if (_connections.Count == 1 && _connections.Contains(previousWaypoint))
        {
            // Only 1 and its previous, just do it!!!
            return previousWaypoint;
        }
        else // Otherwise, find a random one that is different from the previous
        {
            ConnectedWaypoint nextWaypoint;
            int nextIndex = 0;

            do
            {
                nextIndex = Random.Range(0, _connections.Count);
                nextWaypoint = _connections[nextIndex];
                
            } while (nextWaypoint == previousWaypoint);

            return nextWaypoint;
        }
    }
}
