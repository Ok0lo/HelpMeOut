using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dot placement 
/// </summary>
public static class Dotting {

    public static bool IsClosestPositionTo(List<Vector3> candidatePositionList, Vector3 verifiablePosition, Vector3 targetPosition) {
        float closestDistance = Vector3.Distance(verifiablePosition, targetPosition);

        foreach (Vector3 candidate in candidatePositionList) {
            float candidateDistance = Vector3.Distance(targetPosition, candidate);
            if (candidateDistance < closestDistance) return false;
        }

        return true;
    }

}
