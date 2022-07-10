using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace NukeVips.VipCommands
{
    public class VipNick : ICommand
    {
        public string Command => "nick";
        public string[] Aliases => null;
        public string Description => "Comando que permite cambiarse el nombre.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender);
            if (sender.CheckPermission("nk.nick") || CheckPermission(ply))
            {
                if (arguments.Count == 0) { response = "Debes ingresar un nuevo nickname."; return false; }
                string nickname = string.Join(" ", arguments);

                if (Plugin.Nicknames.ContainsKey(ply.UserId))
                    Plugin.Nicknames[ply.UserId] = nickname;
                else
                    Plugin.Nicknames.Add(ply.UserId, nickname);

                ply.DisplayNickname = nickname;
                response = $"Tu nickname a sido cambiado a: '{nickname}'.";
                return true;
            }
            response = "No tienes los permisos para este comando.";
            return false;
        }
        private bool CheckPermission(Player ply)
        {
            if (Plugin.RangosVip.ContainsKey(ply.UserId))
                return true;
            else
                return false;
        }
    }
}
