using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer meshRend;

    public void SetColor(Color color)
    {
        var mat = meshRend.sharedMaterial;
        var newMat = new Material(mat);
        newMat.color = color;
        meshRend.sharedMaterial = newMat;
    }
}
