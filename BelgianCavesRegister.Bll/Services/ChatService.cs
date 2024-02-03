using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Bll.BllInterfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        //public void AddChat(string newMessage, string author)
        //{
        //    _chatRepository.AddChat(newMessage, author);
        //    //try
        //    //{
                
        //    //}
        //    //catch (Exception)
        //    //{

        //    //    throw;
        //    //}

        //}

        public bool Create(Chat chat)
        {
            return _chatRepository.Create(chat);
            //try
            //{
               
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error creating chat: {ex.ToString}");
            //}
            //return true;
        }

        //public void CreateChat(Chat chat)
        //{
        //    _chatRepository.CreateChat(chat);
        //}

        public Chat? Delete(int chat_Id)
        {
            return _chatRepository.Delete(chat_Id);
            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting chat: {ex.ToString}");
            //}
            //return null;
        }

        public IEnumerable<Chat?> GetAll()
        {
            return _chatRepository.GetAll();
        }

        public Chat? GetById(int chat_Id)
        {
            return _chatRepository.GetById(chat_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting chat: {ex.ToString}");
            //}
            //return new Chat();
        }
    }
}
