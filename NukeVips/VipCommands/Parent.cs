using CommandSystem;
using System;

namespace NukeVips.VipCommands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Parent : ParentCommand
    {
        public Parent() => LoadGeneratedCommands();
        public override string Command => "vip";
        public override string[] Aliases => null;
        public override string Description => "Comando para VIPs.";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new VipRole());
            RegisterCommand(new VipSize());
            RegisterCommand(new VipNick());
            RegisterCommand(new VipRank());
            RegisterCommand(new VipColor());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Debes usar alguno de los siguientes comandos." +
                "\n- vip role [Nuevo rol]" +
                "\n- vip size" +
                "\n- vip nick [Nuevo nickname]" +
                "\n- vip rank [Nuevo tag]" +
                "\n- vip color [Nuevo color]";
            return false;
        }
    }
}