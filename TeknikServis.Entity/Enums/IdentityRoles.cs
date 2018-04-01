using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Enums
{
    public enum IdentityRoles:byte
    {
        Admin,
        Operator,
        Teknisyen,
        User,
        Passive
    }
}
