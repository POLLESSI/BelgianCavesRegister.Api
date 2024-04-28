using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Chat;

namespace BelgianCavesRegister.Bll.Interfaces
{
    public interface IChatService
    {
        bool Create(Chat chat);
        void CreateChat(Chat chat);
        IEnumerable<Chat?> GetAll();
        Chat? GetById(int chat_Id);
        Chat? Delete(int chat_Id);
    }
}
