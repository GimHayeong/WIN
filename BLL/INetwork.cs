using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface INetwork
    {
        void StartServer();
        void StopServer();
        bool Connect(string serverIP);
        void DisConnect();
        void Receive();
        void Send(string msg);
    }
}
