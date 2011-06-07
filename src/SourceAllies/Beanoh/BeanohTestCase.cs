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
using SourceAllies.Beanoh.Spring.Wrapper;
#endregion

namespace SourceAllies.Beanoh
{
    /// <summary>
    /// Beanoh is a simple open source way to verify you Spring context. Teams that
    /// leverage Beanoh spend less time focusing on configuring Spring and more time
    /// adding business value
    /// </summary>
    /// <author>David Kessler</author>
    /// <author>Akrem Saed (.NET)</author>
    public class BeanohTestCase
    {
        private BeanohApplicationContext context;

        /// <summary>
        /// Loads every object in the Spring context. Import Spring context files in the bootstrap context. 
        /// BeanohTestCase looks for a Spring context in the classpath with the same name as the test plus "-BeanohContext.xml". 
        /// For eaxmple 'SourceAllies.Anything.SomethingTest' will use 
        /// 'SourceAllies.Anything.SomethingTest-BeanohContext.xml' to bootstrap the Spring context.
        /// </summary>
        public void AssertContextLoading()
        {
            AssertContextLoading(false);
        }

        private void AssertContextLoading(bool AssertUniqueBeans)
        {
           // LoadContext();
          //  iterateBeanDefinitions(new BeanDefinitionAction() {
		//	@Override
		//	public void execute(String name, BeanDefinition definition) {
			//	context.getBean(name);
		//	}
		//});
		//if (assertUniqueBeans)
		//	context.assertUniqueBeans(ignoredDuplicateBeanNames);

        }

        private void loadContext()
        {
            if (context == null)
            { 
            //    String contextLocation = defaultContextLocationBuilder
            //            .build(getClass());
            //    context = new BeanohApplicationContext(contextLocation);
            //    try
            //    {
            //        context.refresh();
            //    }
            //    catch (BeanDefinitionParsingException e)
            //    {
            //        throw e;
            //    }
            //    catch (BeanDefinitionStoreException e)
            //    {
            //        throw new MissingConfigurationException("Unable to locate "
            //                + contextLocation + ".");
            //    }

            //    context.getBeanFactory().registerScope("session",
            //            new SessionScope());
            //    context.getBeanFactory().registerScope("request",
            //            new RequestScope());
            //    MockHttpServletRequest request = new MockHttpServletRequest();
            //    ServletRequestAttributes attributes = new ServletRequestAttributes(
            //            request);
            //    RequestContextHolder.setRequestAttributes(attributes);
            }
        }

    }
}
