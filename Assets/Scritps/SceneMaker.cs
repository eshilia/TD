using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Index
{
    public int x;
    public int y;
    public Index(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

[CreateAssetMenu(menuName = "TileMaker")]
public class SceneMaker : ScriptableObject
{

    [SerializeField]
    protected List<Index> _Tile = new List<Index>();    
    public List<Index> Tile { get { return _Tile; } }

}
