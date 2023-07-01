using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    [ExecuteAlways]
    public class RandomizeBlockOnScene : MonoBehaviour
    {
        private Transform _blocksHolder;
        private List<Transform> _blocks;

        private void Start()
        {
            _blocksHolder = transform;
            _blocks = new List<Transform>();

            foreach (Transform child in _blocksHolder)
                _blocks.Add(child);

            foreach (Transform block in _blocks)
                block.position = new Vector3(Random.Range(-100, 100), Random.Range(-10, 10), Random.Range(-100, 100));
        }
    }
}
