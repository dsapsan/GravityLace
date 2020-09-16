using System.Collections.Generic;
using UnityEngine;

namespace GravityLace
{
    public class GravitySystem : MonoBehaviour
    {
        private static double GravitationalConstant = 6.674e-11;
        private static double TimeSpeed = 86400;

        private List<GravityMass> Masses = new List<GravityMass>();

        //To do: create physics helper class with constants
        public static double ScaleFactor { get; } = 10e-7;

        public static GravitySystem Instance { get; private set; }

        public static void Register(GravityMass mass)
        {
            CheckInstance();
            Instance.Masses.Add(mass);
        }

        public static void Unregister(GravityMass mass)
        {
            CheckInstance();
            Instance.Masses.Remove(mass);
        }

        private static void CheckInstance()
        {
            if (Instance != null)
                return;

            Instance = new GameObject(typeof(GravitySystem).Name).AddComponent<GravitySystem>();
            //DontDestroyOnLoad(Instance.gameObject);
        }

        private void FixedUpdate()
        {
            //Apply forces / acceleration
            foreach (var attractor in Masses)
            {
                if (attractor.Mass < double.Epsilon)
                    continue;

                foreach (var subject in Masses)
                {
                    if (attractor == subject)
                        continue;

                    var r = subject.Position - attractor.Position;
                    var a = (float)(GravitationalConstant * attractor.Mass) / r.sqrMagnitude;
                    subject.Velocity -= a * r.normalized * Time.fixedDeltaTime * (float)TimeSpeed;
                }
            }

            //Apply velocity
            foreach (var subject in Masses)
                subject.Position += subject.Velocity * Time.fixedDeltaTime * (float)TimeSpeed;
        }
    }
}
