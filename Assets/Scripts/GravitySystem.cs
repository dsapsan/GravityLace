using System.Collections.Generic;
using UnityEngine;

namespace GravityLace
{
    public class GravitySystem : MonoBehaviour
    {
        private const double GravitationalConstant = 6.674e-11;
        private const int CalculateSteps = 100;

        private List<GravityMass> Masses = new List<GravityMass>();

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
        }

        private void FixedUpdate()
        {
            //Apply forces / acceleration
            for (var step = 0; step < CalculateSteps; step++)
            {
                for (var i = 0; i < Masses.Count; i++)
                {
                    var attractor = Masses[i];
                    if (attractor.Mass < Mathd.Epsilon)
                        continue;

                    for (var j = 0; j < Masses.Count; j++)
                    {
                        var subject = Masses[j];
                        if (attractor == subject)
                            continue;

                        var r = subject.Position - attractor.Position;
                        var a = GravitationalConstant * attractor.Mass / r.sqrMagnitude;
                        subject.Velocity -= a * Space.SpaceDeltaTime / CalculateSteps * r.normalized;
                    }
                }

            //Apply velocity
            foreach (var subject in Masses)
                subject.Position += Space.SpaceDeltaTime / CalculateSteps * subject.Velocity;
            }
        }
    }
}
