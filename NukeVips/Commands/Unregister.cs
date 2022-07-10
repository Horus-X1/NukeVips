using CommandSystem;
using System;

namespace NukeVips.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Unregister : ICommand
    {
        public string Command => "unregister";
        public string[] Aliases => null;
        public string Description => "Eliminar un usuario VIP registrado.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 1) { response = "Uso del comando: `unregister [id]`"; return false; }

            string userid = arguments.At(0);

            if (!Plugin.RangosVip.ContainsKey(userid)) { response = "El usuario no existe."; return false; }
            else
            {
                Plugin.RangosVip.Remove(userid);

                response = "El usuario a sido eliminado.";
                return true;
            }
        }
    }
}