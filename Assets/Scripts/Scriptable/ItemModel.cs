using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Model", menuName = "Scriptable/Item")]
public class ItemModel : ScriptableObject
{
    public MeshFilter brokenMesh;
    public MeshFilter repairedMesh;
    public MeshRenderer meshRenderer;
}
