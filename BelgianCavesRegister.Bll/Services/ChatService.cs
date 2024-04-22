using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using BelgianCavesRegister.Bll.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public bool Create(Chat chat)
        {
            try
            {
                return _chatRepository.Create(chat);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating chat: {ex.ToString}");
            }
            return false;
        }

        public void CreateChat(Chat chat)
        {
            try
            {
                _chatRepository.CreateChat(chat);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateChat : {ex.ToString}");
            }
        }

        public Chat Delete(int chat_Id)
        {
            try
            {
                return _chatRepository.Delete(chat_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting chat: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Chat> GetAll()
        {
            return _chatRepository.GetAll();
        }

        public Chat GetById(int chat_Id)
        {

            try
            {
                return _chatRepository.GetById(chat_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting chat: {ex.ToString}");
            }
            return null;
        }
    }
}
