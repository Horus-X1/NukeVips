using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using System;
using System.Linq;

namespace NukeVips.VipCommands
{
    public class VipRole : ICommand
    {
        private int Uses = 0;
        public string Command => "role";
        public string[] Aliases => null;
        public string Description => "Permite cambiar el rol al principio de ronda.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender);
            if (!Enum.TryParse(arguments.At(0), true, out RoleType role)) { response = "El rol ingresado no es valido."; return false; }

            if (CheckPermission(ply, role))
            {
                if (!Round.IsStarted || Round.ElapsedTime.TotalSeconds > 25) { response = "La ronda no ha empezado o ya pasaron mas de 25 segundos."; return false; }
                if (EventHandlers.CommandUsed.Contains(ply)) { response = "Ya usaste el comando en esta ronda."; return false; }

                if (!Plugin.Usos.ContainsKey(ply.UserId))
                    Plugin.Usos.Add(ply.UserId, Uses);

                if (Plugin.Usos[ply.UserId] == 0) { response = "Ya no te quedan usos."; return false; }

                switch (role.GetTeam())
                {
                    case Team.SCP:
                        if (Player.Get(Team.SCP).Count() > 5 || Player.Get(role).Count() > 0 || ply.IsScp) { response = "No puedes usar este comando por alguna de estas razones:\n- Ya hay mas de 5 SCPs.\n- Este SCP ya esta en uso.\n- Ya eres SCP."; return false; }
                        break;
                    default:
                        break;
                }
                ply.SetRole(role, Exiled.API.Enums.SpawnReason.Respawn);
                EventHandlers.CommandUsed.Add(ply);
                --Plugin.Usos[ply.UserId];

                response = $"Te has vuelto otro rol. Te quedan: {Plugin.Usos[ply.UserId]}/{Uses} usos.";
                return true;
            }
            response = "No tienes el permiso para este comando o el rol no es valido para tu rango.";
            return false;
        }
        private bool CheckPermission(Player ply, RoleType role)
        {
            if (!Plugin.RangosVip.TryGetValue(ply.UserId, out string rank))
                return false;

            switch (rank.ToLower())
            {
                case "vipboost":
                    if (!RoleList.BoostRoles.Contains(role)) return false;
                    Uses = 1;
                    return true;
                case "vipsafe":
                    if (!RoleList.SafeRoles.Contains(role)) return false;
                    Uses = 2;
                    return true;
                case "vipsafep":
                    if (!RoleList.SafeRoles.Contains(role)) return false;
                    Uses = 5;
                    return true;
                case "vipeuclid":
                    if (!RoleList.EuclidRoles.Contains(role)) return false;
                    Uses = 5;
                    return true;
                case "vipeuclidp":
                    if (!RoleList.EuclidRoles.Contains(role)) return false;
                    Uses = 8;
                    return true;
                case "vipketer":
                    if (!RoleList.KeterRoles.Contains(role)) return false;
                    Uses = 8;
                    return true;
                case "vipketerp":
                    if (!RoleList.KeterRoles.Contains(role)) return false;
                    Uses = 12;
                    return true;
                case "vipnuke":
                    if (!RoleList.KeterRoles.Contains(role)) return false;
                    Uses = 999;
                    return true;
                default:
                    return false;
            }
        }
    }
}