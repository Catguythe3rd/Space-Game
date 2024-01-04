using Pathfinding;
using System.Collections;
using UnityEngine;

public class PathUpdate : VersionedMonoBehaviour
{
    IAstarAI AI;

    private void FixedUpdate()
    {
        AstarPath.active.Scan();
    }
}
