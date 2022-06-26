using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Interface
{
    public interface IChatService
    {
        Task<Chat> SendMessage(Chat chat);
        Task<Chat> DeleteMessage(string id, string username);
        Task<List<Chat>> GetMessages(string sender, string reciever);
    }
}
