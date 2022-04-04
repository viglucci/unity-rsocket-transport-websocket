using System;
using JamesFrowen.SimpleWeb;
using Viglucci.UnityRSocket;

namespace Viglucci.UnityRSocketTransportWebSocket
{
    public class WebsocketTransport : IClientTransport
    {
        private readonly string _scheme;
        private readonly string _host;
        private readonly int _port;
        private readonly int _sendTimeout;
        private readonly int _receiveTimeout;
        private readonly int _messagesPerTick;
        private SimpleWebClient _client;

        public WebsocketTransport(
            string scheme,
            string host,
            int port,
            int sendTimeout,
            int receiveTimeout,
            int messagesPerTick)
        {
            _scheme = scheme;
            _host = host;
            _port = port;
            _sendTimeout = sendTimeout;
            _receiveTimeout = receiveTimeout;
            _messagesPerTick = messagesPerTick;
        }

        public IDuplexConnection Connect()
        {
            TcpConfig tcpConfig =
                new TcpConfig(false, _sendTimeout, _receiveTimeout);

            _client = SimpleWebClient.Create(ushort.MaxValue, _messagesPerTick, tcpConfig);

            UriBuilder builder = new UriBuilder
            {
                Scheme = _scheme,
                Host = _host,
                Port = _port
            };

            WebSocketTransportDuplexConnection connection
                = new WebSocketTransportDuplexConnection(_client);

            _client.Connect(builder.Uri);
            
            return connection;
        }

        public void ProcessMessages()
        {
            _client.ProcessMessageQueue();
        }
    }
}