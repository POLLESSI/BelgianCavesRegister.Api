using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IHashingPassword
    {
        public Task<string> CreateNUser(NUserDTO create);
        public Task<string> NUserVerify(NUserDTO verify);
    }
}
