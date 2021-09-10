using System.Collections.Generic;
using UnityEngine;

public sealed class ChainsOfResponsibility : MonoBehaviour
{
    [SerializeField] private List<GameHandler> _gameHandlers;

    private void Start()
    {
         _gameHandlers[0].Handle();
         for (var i = 1; i < _gameHandlers.Count; i++)
         {
                _gameHandlers[i - 1].SetNext(_gameHandlers[i]);
         }
    }
}
