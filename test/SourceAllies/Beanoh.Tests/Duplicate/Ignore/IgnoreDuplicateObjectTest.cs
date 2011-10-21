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

namespace SourceAllies.Beanoh.Duplicate.Ignore
{
    [TestFixture]
    class IgnoreDuplicateObjectTest : BeanohTestCase
    {
        [Test]
        public void TestDups()
        {
            try
            {
                IgnoreDuplicateObjectNames("person");
                AssertUniqueObjectContextLoading();
                Assert.Fail();
            }
            catch (DuplicateObjectDefinitionException e)
            {
                Assert.AreEqual(
                        "Object 'person2' was defined 2 times."
                        + Environment.NewLine
                        + "Either remove duplicate object definitions or ignore them with the 'IgnoreDuplicateObjectNames' method."
                        + Environment.NewLine
                        + "Configuration locations:"
                        + Environment.NewLine
                        + "assembly [Beanoh.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], resource [SourceAllies.Beanoh.Duplicate.Ignore.FirstIgnoreDuplicate-context.xml] line 20"
                        + Environment.NewLine
                        + "assembly [Beanoh.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], resource [SourceAllies.Beanoh.Duplicate.Ignore.SecondIgnoreDuplicate-context.xml] line 20",
                        e.Message);
            }
        }
    }
}
