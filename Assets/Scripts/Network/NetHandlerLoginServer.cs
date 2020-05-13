using Lidgren.Network;
using StarloadCommons.Network;
using StarloadCommons.Network.Login;
using StarloadCommons.Network.Login.Client;

namespace Starload.Network
{
    public class NetHandlerLoginServer : INetHandlerLoginServer
    {
        private NetworkSystem _system;
        private NetworkConnection _connection;

        public NetHandlerLoginServer(NetworkSystem system, NetworkConnection connection)
        {
            _system = system;
            _connection = connection;
        }
        
        public void ProcessLoginStart(CPacketLoginStart packetIn)
        {
            //TODO Verify data
            //TODO sendPacket SPacketLoginSuccess
            throw new System.NotImplementedException();
        }

        public void OnStatusChange(NetConnectionStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}