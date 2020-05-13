using System.Collections.Generic;
using Lidgren.Network;
using StarloadCommons.Network;
using UnityEngine;

namespace Starload.Network
{
    public class NetworkServer : NetworkSystem
    {
        private NetServer _server;
        private Dictionary<long, NetworkConnection> _connections = new Dictionary<long, NetworkConnection>();

        public NetworkServer(NetServer server) : base(server)
        {
            _server = server;
        }
    
        public static NetworkServer Create()
        {
            NetPeerConfiguration configuration = new NetPeerConfiguration("Starload")
            {
                Port = 4242
            };
            NetServer server = new NetServer(configuration);
            server.Start();
            return new NetworkServer(server);
        }

        public override NetworkConnection GetConnection(NetworkSystem system, NetIncomingMessage message)
        {
            _connections.TryGetValue(message.SenderConnection.RemoteUniqueIdentifier, out NetworkConnection connection);
            return connection;
        }

        public override void OnConnectionCreate(NetworkSystem system, NetConnection netConnection)
        {
            NetworkConnection con = new NetworkConnection(netConnection);
            con.AddNetworkChannel(NetworkChannel.LOGIN, new NetHandlerLoginServer(this, con));
            //TODO Add Channel Handlers
            _connections.Add(netConnection.RemoteUniqueIdentifier, con);
        }

        public override void OnDisconnect(NetworkSystem system, NetworkConnection connection, NetIncomingMessage message)
        {
            Debug.Log("Connection Closed: " + message.PeekString());
        }
    }
}
