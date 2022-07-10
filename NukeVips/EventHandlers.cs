using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace NukeVips
{
    public class EventHandlers
    {
        public static List<Player> CommandUsed = new List<Player>();

        public void OnVerified(VerifiedEventArgs ev)
        {
            Timing.CallDelayed(1f, () =>
            {
                if (Plugin.Nicknames.TryGetValue(ev.Player.UserId, out string nickname))
                    ev.Player.DisplayNickname = nickname;

                if (Plugin.Ranknames.TryGetValue(ev.Player.UserId, out string rankname))
                    ev.Player.RankName = rankname;

                if (Plugin.Colors.TryGetValue(ev.Player.UserId, out string color))
                    ev.Player.RankColor = color;
            });
        }
    }
}