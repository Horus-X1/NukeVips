using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace NukeVips.VipCommands
{
    public class VipRank : ICommand
    {
        public string Command => "rank";
        public string[] Aliases => null;
        public string Description => "Permite cambiarse el tag del rango.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender);
            if (sender.CheckPermission("nk.rank") || CheckPermission(ply))
            {
                if (arguments.Count == 0) { response = "Debes ingresar un nuevo tag."; return false; }
                string rank = string.Join(" ", arguments);

                if (Plugin.Ranknames.ContainsKey(ply.UserId))
                    Plugin.Ranknames[ply.UserId] = rank;
                else
                    Plugin.Ranknames.Add(ply.UserId, rank);

                ply.RankName = rank;
                response = $"Tu tag a sido cambiado a: '{rank}'.";
                return true;
            }
            response = "No tienes los permisos para este comando.";
            return false;
        }
        private bool CheckPermission(Player ply)
        {
            if (!Plugin.RangosVip.TryGetValue(ply.UserId, out string rank))
                return false;

            switch (rank.ToLower())
            {
                case "vipketerp":
                case "vipnuke":
                    return true;
                default:
                    return false;
            }
        }
    }
}