using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.UserInput
{
    public class InputShoot : IUserShoots
    {
        public event Action<float[]> TakeShoot = delegate (float[] f) { };

        public void GetShoot()
        {
            if (Input.GetMouseButtonDown(MouseButtonManager.LEFTBUTTON))
            {
                float[] mousePosition = new float[2] { Input.mousePosition.x, Input.mousePosition.y };
                TakeShoot.Invoke(mousePosition);
            }
        }
    }
}
