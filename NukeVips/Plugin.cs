using Exiled.API.Features;
using System.Collections.Generic;
using Player = Exiled.Events.Handlers.Player;

namespace NukeVips
{
    public class Plugin : Plugin<Config>
    {
        public static new Config Config;
        private EventHandlers handler;

        public static Dictionary<string, string> RangosVip;
        public static Dictionary<string, int> Usos;

        public static Dictionary<string, string> Nicknames;
        public static Dictionary<string, string> Ranknames;
        public static Dictionary<string, string> Colors;

        public override void OnEnabled()
        {
            handler = new EventHandlers();
            Player.Verified += handler.OnVerified;

            CheckDictionaries();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Player.Verified -= handler.OnVerified;
            handler = null;

            base.OnDisabled();
        }
        private void CheckDictionaries()
        {
            if (RangosVip == null) RangosVip = new Dictionary<string, string>();
            if (Usos == null) Usos = new Dictionary<string, int>();

            if (Nicknames == null) Nicknames = new Dictionary<string, string>();
            if (Ranknames == null) Ranknames = new Dictionary<string, string>();
            if (Colors == null) Colors = new Dictionary<string, string>();
        }
    }
}