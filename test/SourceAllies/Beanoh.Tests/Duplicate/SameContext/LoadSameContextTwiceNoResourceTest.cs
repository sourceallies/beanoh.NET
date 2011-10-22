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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SourceAllies.Beanoh.Util;
using SourceAllies.Beanoh.Exception;
#endregion
namespace SourceAllies.Beanoh.Duplicate.SameContext
{
    [TestFixture]
    class LoadSameContextTwiceNoResourceTest : BeanohTestCase
    {
        /// <summary>
        /// this tests when we have a duplicate object definition but we cannot resolve from which resource was the 
        /// definition obtained. An example would be when Spring.net creates the object using proxies at runtime for 
        /// data sources.
        /// </summary>
        [Test]
        public void TestDups()
        {
            try
            {
                AssertUniqueObjectContextLoading();
                Assert.Fail();
            }
            catch (DuplicateObjectDefinitionException e)
            {
                Assert.AreEqual(
                 "Object 'dataSource' was defined 2 times."
                    + Environment.NewLine
                    + "Either remove duplicate object definitions or ignore them with the 'IgnoreDuplicateObjectNames' method."
                    + Environment.NewLine
                    + "Configuration locations:"
                    + Environment.NewLine
                    + "Spring.Data.Common.DbProviderFactoryObject"
                    + Environment.NewLine
                    + "Spring.Data.Common.DbProviderFactoryObject",
                    e.Message);
            }
        }
    }
}
