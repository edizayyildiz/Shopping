using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service
{
    public class DescribeAttribute : Attribute
    {
        public string Desc { get; }
        public CommandType Type { get; }
        public Authorities Auth { get; }
        public DescribeAttribute(CommandType type, Authorities auth, string desc)
        {
            Desc = desc;
            Type = type;
            Auth = auth;
        }
    }
    public enum CommandType
    {
        Cms = 1,
        Commerce = 2,
        Customer = 3,
        Setting = 4,
        Store = 5,
        System = 6,
        User = 7
    }
    public enum Authorities
    {
        None = 0,
        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4
    }
}
