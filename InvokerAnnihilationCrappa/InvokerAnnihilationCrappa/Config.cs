using System;
using Ensage.Common.Menu;
using Ensage.SDK.Menu;
using InvokerAnnihilationCrappa.Features;

namespace InvokerAnnihilationCrappa
{
    public class Config : IDisposable
    {
        public readonly Invoker Invoker;

        public Config(Invoker invoker)
        {
            Invoker = invoker;
            Factory = MenuFactory.Create("Invoker Annihilation");
            ComboKey = Factory.Item("Combo Key", new KeyBind('G'));
            FontSize = Factory.Item("Font Size", new Slider(13, 1, 100));
            InvokeTime = Factory.Item("Time between spheres in combo", new Slider(20, 1, 200));
            AfterInvokeDelay = Factory.Item("Delay after Invoke", new Slider(300, 1, 500));
            AbilityPanel = new AbilityPanel(this);
            ComboPanel = new ComboPanel(this);
            SmartSphere = new SmartSphere(this);
            AutoSunStrike = new AutoSunStrike(this);
            Prepare = new Prepare(this);
        }

        public MenuItem<Slider> AfterInvokeDelay { get; set; }

        public MenuItem<Slider> InvokeTime { get; set; }

        public Prepare Prepare { get; set; }

        public AutoSunStrike AutoSunStrike { get; set; }

        public ComboPanel ComboPanel { get; set; }

        public SmartSphere SmartSphere { get; set; }

        public AbilityPanel AbilityPanel { get; set; }

        public MenuItem<Slider> FontSize { get; set; }

        public MenuItem<KeyBind> ComboKey { get; set; }

        public MenuFactory Factory { get; }

        public void Dispose()
        {
            AbilityPanel.OnDeactivate();
            SmartSphere.OnDeactivate();
            ComboPanel.OnDeactivate();
            AutoSunStrike.OnDeactivate();
            Factory?.Dispose();
        }
    }
}