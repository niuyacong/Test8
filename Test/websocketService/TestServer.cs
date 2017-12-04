using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.websocketService
{
    public  class TestServer : AppServer<TestSession>
    {
    public static void appServer_NewSessionConnected(AppSession session)
        {
            session.Send("Welcome to SuperSocket Telnet Server");
        }
    }
}