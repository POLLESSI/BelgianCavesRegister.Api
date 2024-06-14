
using System.Collections.Generic;
using System.Linq;
using BelgianCavesRegister.Dal.Entities;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Chat;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IChatRepository
    {
    #nullable disable
        bool Create(Chat chat);
        void CreateChat(Chat chat);
        IEnumerable<Chat> GetAll();
        Chat? GetById(int chat_Id);
        Chat? Delete(int chat_Id);
    }
}
