using RTServer.Core;
using RTShared.Commands;
using RTShared.Misc;

namespace RTServer.Commands
{
    public class CMD_IPPardon : CMD_Base
    {
        public CMD_IPPardon()
        {
            Prefix = "pardonip";
            Description = "Pardons the selected ip from the server";
            ParameterCount = 1;
        }

        public override void Action()
        {
            if (!Master.IpBansConfig.CheckForIPBan(CMD_Base.CommandParameters[0])) Printer.Warning($"IP '{CMD_Base.CommandParameters[0]}' wasn't banned from the server");
            else
            {
                Master.IpBansConfig.Remove(CMD_Base.CommandParameters[0]);
                Printer.Warning($"IP '{CMD_Base.CommandParameters[0]}' has been pardoned from the server");   
            }
        }
    }
}