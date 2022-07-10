using System.Collections.Generic;

namespace NukeVips
{
    public class RoleList
    {
        public static List<RoleType> BoostRoles = new List<RoleType>
        { RoleType.Scp93989, RoleType.Scp93953, RoleType.Scp173, RoleType.Scp079, RoleType.Scp049 };

        public static List<RoleType> SafeRoles = new List<RoleType>
        { RoleType.Scp93989, RoleType.Scp93953, RoleType.Scp173, RoleType.Scp079, RoleType.Scp049, RoleType.ClassD };

        public static List<RoleType> EuclidRoles = new List<RoleType>
        { RoleType.Scp93989, RoleType.Scp93953, RoleType.Scp173, RoleType.Scp096, RoleType.Scp079, RoleType.Scp049, RoleType.Scientist, RoleType.ClassD };

        public static List<RoleType> KeterRoles = new List<RoleType>
        { RoleType.Scp93989, RoleType.Scp93953, RoleType.Scp173, RoleType.Scp106, RoleType.Scp096, RoleType.Scp079, RoleType.Scp049, RoleType.FacilityGuard, RoleType.Scientist, RoleType.ClassD };
    }
}