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

namespace SourceAllies.Beanoh.Duplicate.AOP
{
    [TestFixture]
    class DuplicateAopObjectTest : BeanohTestCase
    {
        [Test]
        public void TestScanning() 
        {
            try
            {
                AssertUniqueObjectContextLoading();
                Assert.Fail();
            }
            catch (DuplicateObjectDefinitionException e)
            {
                Assert.AreEqual(
                    "Object 'autoProxyCreator' was defined 2 times."
                    + Environment.NewLine
                    + "Either remove duplicate object definitions or ignore them with the 'IgnoreDuplicateObjectNames' method."
                    + Environment.NewLine
                    + "Configuration locations:"
                    + Environment.NewLine
                    + "assembly [Beanoh.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], resource [SourceAllies.Beanoh.Duplicate.AOP.FirstDuplicateAop-context.xml] line 22"
                    + Environment.NewLine
                    + "assembly [Beanoh.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], resource [SourceAllies.Beanoh.Duplicate.AOP.SecondDuplicateAop-context.xml] line 22",
                    e.Message);

            }
        }
    }
}
