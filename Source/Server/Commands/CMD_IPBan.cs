using RTNetwork.Components;
using RTServer.Core;
using RTServer.Hooks.TCPNetwork;
using RTShared.Commands;
using RTShared.Misc;

namespace RTServer.Commands
{
    public class CMD_IPBan : CMD_Base
    {
        public CMD_IPBan()
        {
            Prefix = "banip";
            Description = "Bans the selected ip from the server";
            ParameterCount = 1;
        }

        public override void Action()
        {
            if (Master.IpBansConfig.CheckForIPBan(CMD_Base.CommandParameters[0])) Printer.Warning($"IP '{CMD_Base.CommandParameters[0]}' was already banned from the server");
            else
            {
                Master.IpBansConfig.Add(CMD_Base.CommandParameters[0]);
                Printer.Warning($"IP '{CMD_Base.CommandParameters[0]}' has been banned from the server");
            
                List<ServerClient> toKick = ServerNetwork.GetConnectedClients().Where(fetch => fetch.IP == CMD_Base.CommandParameters[0]).ToList();
                foreach (ServerClient client in toKick) client.Listener.MarkForDisconnect();   
            }
        }
    }
}