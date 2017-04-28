using System;
using System.Threading.Tasks;

namespace studentms
{
    public interface IClient
    {
         Task<string> GetFee();
    }
}
