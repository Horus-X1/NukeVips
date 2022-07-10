using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using UnityEngine;

namespace NukeVips.VipCommands
{
    public class VipSize : ICommand
    {
        public string Command => "size";
        public string[] Aliases => null;
        public string Description => "Comando para cambiarse de tamaño.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender);
            if (sender.CheckPermission("nk.size") || CheckPermission(ply))
            {
                if (!Round.IsStarted || ply.IsDead || ply.IsScp) { response = "No puedes usar este comando mientras:\n- La ronda no haya empezado.\n- Estes muerto.\n- Eres un SCP."; return false; }

                ply.Scale = Vector3.one * 0.8f;
                response = "Tu tamaño a sido cambiado.";
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