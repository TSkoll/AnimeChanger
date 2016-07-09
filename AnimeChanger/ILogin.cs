using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger
{
    public interface ILogin
    {
        Secrets secrets { get; set; }
        void PassSecrets();
    }
}
