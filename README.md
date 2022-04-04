# unity-rsocket-transport-websocket

A Unity Compatible WebSocket transport for [Unity RSocket](https://github.com/viglucci/unity-rsocket).

## Dependencies

- [io.viglucci.unityrsocket@0.2.0](https://github.com/viglucci/unity-rsocket)
- [com.james-frowen.simplewebtransport@1.3.0](https://github.com/James-Frowen/SimpleWebTransport)

## Example

```cs
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
```