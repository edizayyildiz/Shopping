using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Read, "Kullanıcı arama yapar.")]
    public class SearchUser : Command
    {
        public string Text { get; set; }
        public virtual string Gender { get; set; }
        public virtual Guid? OrganizationUid { get; set; }
        public virtual Guid? RoleUid { get; set; }
        public bool? IsUser { get; set; }
        public bool IsPaging { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsSorting { get; set; }
        public string OrderDirection { get; set; }
        public string OrderField { get; set; }
    }
}
