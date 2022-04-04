using System.Collections.Generic;
using UnityEngine;
using Viglucci.UnityRSocket;
using Viglucci.UnityRSocket.Scheduling;

namespace Viglucci.UnityRSocketTransportWebSocket.Example
{
    public class WebSocketTransportExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            WebsocketTransport transport = new WebsocketTransport(
                "ws", 
                "localhost", 
                7000, 
                5000, 
                20000, 
                5000);

            RSocketConnector connector = new RSocketConnector(
                transport,
                new SetupOptions(3000, 1000, new List<byte>(), new List<byte>()),
                new MonoBehaviorScheduler());

            RSocketRequester rSocketRequester = connector.Bind();
        }
    }
}
