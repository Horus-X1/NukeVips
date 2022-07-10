using CommandSystem;
using System;

namespace NukeVips.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RestartUses : ICommand
    {
        public string Command => "restartuses";
        public string[] Aliases => new string[] { "ru" };
        public string Description => "Reiniciar usos de comandos.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Plugin.Usos.Clear();
            response = "Los usos han sido reiniciados correctamente.";
            return true;
        }
    }
}