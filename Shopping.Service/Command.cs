using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Shopping.Service
{
    public abstract class Command
    {
        private string _apptoken;
        private Guid _token;
        private bool _tokenok;
        private string _ip;
        private string _host;

        public void SetInformation(string ip, string host)
        {
            _ip = ip;
            _host = host;
        }

        internal string Ip => _ip;

        internal string Host => _host;

        internal string GetDescription()
        {
            var attr = GetType().GetTypeInfo().GetCustomAttribute<DescribeAttribute>();
            if (attr == null) return "";
            return ((DescribeAttribute)attr).Desc;
        }
        //Application Token
        public string GetAppToken() { return _apptoken; }
        public void SetAppToken(string value)
        {
            _apptoken = value;
        }
        public Command WithAppToken(string apptoken)
        {
            _apptoken = apptoken;
            return this;
        }
        //User Token Login tablosundan kontrol edilir
        public Guid GetToken() { return _token; }
        public void SetToken(Guid value)
        {
            _token = value;
        }
        public Command WithToken(Guid token)
        {
            _token = token;
            return this;
        }

        public bool GetTokenOk() { return _tokenok; }
        public void SetTokenOk(bool value)
        {
            _tokenok = value;
        }

    }
}
