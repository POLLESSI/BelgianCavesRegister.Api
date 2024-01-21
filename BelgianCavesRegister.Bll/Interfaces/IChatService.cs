using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.BllInterfaces
{
    public interface IChatService
    {
        void AddChat(string newMessage, string author);
        bool Create(Chat chat);
        IEnumerable<Chat?> GetAll();
        Chat? GetById(int chat_Id);
        Chat? Delete(int chat_Id);
    }
}
