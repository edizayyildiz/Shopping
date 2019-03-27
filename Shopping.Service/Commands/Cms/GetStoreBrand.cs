﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Bir mağaza markası getirir.")]
    public class GetStoreBrand : Command
    {
        public string Id { get; set; }
    }
}
