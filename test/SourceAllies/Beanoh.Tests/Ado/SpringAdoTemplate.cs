
#region License
/* 
 * Copyright (c) 2011 Source Allies
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation version 3.0.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, please visit
 * http://www.gnu.org/licenses/lgpl-3.0.txt.
*/
#endregion

#region Imports
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Spring.Data.Generic;
using Spring.Data.Common;
#endregion

namespace SourceAllies.Beanoh.Ado
{
    /// <summary>
    ///  a custom AdoTemplate implementation that attempts to open a connection once it has been configured. This 
    ///  is helpful for testing the convenience IDbProvider mock that Beanoh.NET provides to simplify 
    ///  overriding of dbProviders. 
    /// </summary>
    /// <author>Akrem Saed (.NET)</author>
    class SpringAdoTemplate : AdoTemplate
    {

        public override void AfterPropertiesSet()
        {
            //after this object is created by Spring.NET , we will try to open a database connection just to be sure it's wired
            base.AfterPropertiesSet();
            IDbConnection connection = this.DbProvider.CreateConnection();
            connection.Open();
            connection.Close();
        }


    }

}
