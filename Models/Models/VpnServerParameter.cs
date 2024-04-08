using Models.Enums;
using Models.Queries;

namespace Models.Models
{
    public class VpnServerParameter
    {
        public string CmdLineParameter { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
   
        public VpnServerParameter(string cmdLineParameter, string type, int id)
        {
            CmdLineParameter = cmdLineParameter;
            Type = type;
            Id = id;
        }
    }
}