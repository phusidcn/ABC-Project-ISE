using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Helper
{
    public interface IHavePassword
    {
        System.Security.SecureString Password { get; }
        System.Security.SecureString RePassword { get; }
    }
}
