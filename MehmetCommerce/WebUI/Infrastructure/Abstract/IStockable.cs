﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Infrastructure.Abstract
{
    public interface IStockable
    {
        int GetStockCount();
    }
}