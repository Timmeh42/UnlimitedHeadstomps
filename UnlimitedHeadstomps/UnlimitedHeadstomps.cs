using System;
using BepInEx;
using System.Reflection;
using System.Linq;

namespace UnlimitedHeadstomps
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.Timmeh42.UnlimitedHeadstomps", "UnlimitedHeadstomps", "1.0.0")]
    public class UnlimitedHeadstomps : BaseUnityPlugin
    {
        public void Awake()
        {
            On.EntityStates.Headstompers.HeadstompersCooldown.OnEnter += (orig, self) =>
            {
                Assembly assembly = self.GetType().Assembly;
                Type HSCooldown = assembly.GetTypes().First(t => t.IsClass && t.Namespace == "EntityStates.Headstompers" && t.Name == "HeadstompersCooldown");

                HSCooldown.GetField("baseDuration", BindingFlags.Static | BindingFlags.Public).SetValue(null, 0f);
                orig(self);
            };
        }
    }
}
