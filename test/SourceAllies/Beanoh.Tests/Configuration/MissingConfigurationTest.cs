﻿#region License
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
#endregion


namespace SourceAllies.Beanoh.Configuration
{
    [TestFixture]
    class MissingConfigurationTest : BeanohTestCase 
    {
          [Test]
          public void TestWiring()
          {
              try
              {
                  AssertContextLoading();
                  Assert.Fail();

              }
              catch (System.Exception e)
              {
                  DefaultContextLocationBuilder contextBuilder = new DefaultContextLocationBuilder();
                  
                  Assert.True(e.ToString().Contains("Unable to load " +  contextBuilder.build(this.GetType()) ));
              }
          }
    }
}
