using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Collections.Generic;

namespace NukeVips.VipCommands
{
    public class VipColor : ICommand
    {
        private readonly List<string> ColoresDisponibles = new List<string>()
        { "pink", "red", "brown", "silver", "light_green", "crismon", "aqua", "tomato", "yellow", "magenta", "blue_green", "orange", "green", "emerald", "carmine", "nickel", "mint", "army_green", "pumpkin" };

        public string Command => "color";
        public string[] Aliases => null;
        public string Description => "Permite cambiarse el color del tag.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender);
            if (sender.CheckPermission("nk.color") || CheckPermission(ply))
            {
                if (arguments.Count == 0) { response = "Debes ingresar un nuevo color."; return false; }
                string color = string.Join(" ", arguments);

                if (!ColoresDisponibles.Contains(color)) { response = "El color ingresado no es valido."; return false; }

                if (Plugin.Colors.ContainsKey(ply.UserId))
                    Plugin.Colors[ply.UserId] = color;
                else
                    Plugin.Colors.Add(ply.UserId, color);

                ply.RankColor = color;
                response = $"Tu color del tag a sido cambiado a: '{color}'.";
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
                case "vipeuclid":
                case "vipeuclidp":
                case "vipketer":
                case "vipketerp":
                case "vipnuke":
                    return true;
                default:
                    return false;
            }
        }
    }
}