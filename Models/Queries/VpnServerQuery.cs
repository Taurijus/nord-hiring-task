using System.Collections.Generic;
using Models.Enums;
using Models.Models;

namespace Models.Queries
{
    public class VpnServerQuery
    {
        private readonly List<VpnServerParameter> _parameters;
        public IReadOnlyList<VpnServerParameter> parameters => _parameters;

        public VpnServerQuery(List<VpnServerParameter> parameters)
        {
            _parameters = parameters;
        }

        public VpnServerQuery()
        {
            _parameters = new List<VpnServerParameter>();
        }

        public VpnServerQuery AddParameter(VpnServerParameter parameter)
        {
            _parameters.Add(parameter);
            return this;
        }
    }

}
