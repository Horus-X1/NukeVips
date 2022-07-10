using CommandSystem;
using System;

namespace NukeVips.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Register : ICommand
    {
        public string Command => "register";
        public string[] Aliases => null;
        public string Description => "Registrar usuarios como VIPs.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 2) { response = "Uso del comando: `register [id] [rango]`"; return false; }

            string userid = arguments.At(0);
            string rango = arguments.At(1);

            if (Plugin.RangosVip.ContainsKey(userid))
            {
                Plugin.RangosVip[userid] = rango;

                response = "Se rango del usuario a sido actualizado.";
                return true;
            }
            else
            {
                Plugin.RangosVip.Add(userid, rango);

                response = "El usuario a sido registrado.";
                return true;
            }
        }
    }
}