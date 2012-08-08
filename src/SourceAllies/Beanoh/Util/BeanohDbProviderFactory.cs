
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
using Spring.Data.Common;
using Moq;
#endregion


namespace SourceAllies.Beanoh.Util
{
    /// <summary>
    ///  Factory that constructs a mocked IDbProvider with some methods stubbed so it can be used 
    ///  to override object definitions that require a dbProvider object.
    /// </summary>
    /// <author>Akrem Saed (.NET)</author>
    class BeanohDbProviderFactory
    {
        
        static public IDbProvider CreateMockedDbProvider()
        {
            Mock<IDbProvider> mockDbProvider = new Mock<IDbProvider>();
            Mock<IDbConnection> mockDbConnection = new Mock<IDbConnection>();
            Mock<IDbDataAdapter> mockDbDataAdapter = new Mock<IDbDataAdapter>();

            mockDbProvider.Setup(foo => foo.CreateConnection()).Returns(mockDbConnection.Object);
            mockDbProvider.Setup(foo => foo.CreateDataAdapter()).Returns(mockDbDataAdapter.Object);
            
            return mockDbProvider.Object;
        }
      

    }
}
