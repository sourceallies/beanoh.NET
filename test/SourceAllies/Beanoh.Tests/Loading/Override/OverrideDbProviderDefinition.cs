
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
using NUnit.Framework;
#endregion


namespace SourceAllies.Beanoh.Loading.Override
{
    /// <summary>
    ///  This test fixture is for testing that if we have any objects that depends on an IDbProvider then 
    ///  it can be replaced with Beanoh.NET's mocked implementation. 
    /// </summary>
    /// <author>Akrem Saed (.NET)</author>
     [TestFixture]
    class OverrideDbProviderDefinition : BeanohTestCase
    {
         [Test]
         public void TestWiring()
         {
             AssertContextLoading();
         }
    }
}
