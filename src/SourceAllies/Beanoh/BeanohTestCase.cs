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
using SourceAllies.Beanoh.Util;
using SourceAllies.Beanoh.Exception;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Parsing;
using Spring.Objects.Factory;
using NUnit.Framework;
#endregion

namespace SourceAllies.Beanoh
{
    /// <summary>
    /// Beanoh.NET is a simple open source way to verify you Spring.NET context. Teams that
    /// leverage Beanoh.NET spend less time focusing on configuring Spring and more time
    /// adding business value
    /// </summary>
    /// <author>Akrem Saed</author>
    public class BeanohTestCase
    {
        private BeanohApplicationContext context;
        private ISet<String> ignoredClassNames;
        private ISet<String> ignoredNamespaces;
        private ISet<String> ignoredDuplicateObjectNames;
        private DefaultContextLocationBuilder defaultContextLocationBuilder = new DefaultContextLocationBuilder();

        [SetUp]
        public void SetUp()
        {
            ignoredClassNames = new HashSet<String>();
            ignoredNamespaces = new HashSet<String>();
            ignoredDuplicateObjectNames = new HashSet<String>();
        }

        /// <summary>
        /// Loads every object in the Spring.NET context. Import Spring context files in the bootstrap context. 
        /// BeanohTestCase looks for a Spring context in the classpath with the same name as the test class plus 
        /// "-BeanohContext.xml". For eaxmple 'SourceAllies.Anything.SomethingTest' will use 
        /// 'SourceAllies.Anything.SomethingTest-BeanohContext.xml' to bootstrap the Spring context.
        /// </summary>
        public void AssertContextLoading()
        {
            AssertContextLoading(false);
        }

        private void AssertContextLoading(bool AssertUniqueBeans)
        {
            LoadContext();
            IterateBeanDefinitions(new ObjectDefinitionGetter(this));

            if (AssertUniqueBeans)
            {
                context.AssertUniqueObjects(ignoredDuplicateObjectNames);
            }

        }

        /// <summary>
        /// Test method that tests there are no duplicate object ids used in the Spring.NET context.
        /// </summary>
        public void AssertUniqueObjectContextLoading()
        {
            AssertContextLoading(true);
        }

        public void IgnoreDuplicateObjectNames(params string[] objectNames)
        {
            foreach (string objectName in objectNames)
            {
                ignoredDuplicateObjectNames.Add(objectName);
            }
        }


        private void IterateBeanDefinitions(IObjectDefinitionAction action)
        {
            String[] names = context.GetObjectDefinitionNames();
            foreach (String name in names)
            {
                IObjectDefinition objectDefinition = context.ObjectFactory.GetObjectDefinition(name);
                if (!objectDefinition.IsAbstract)
                {
                    action.Execute(name, objectDefinition);
                }
            }
        }

        private void LoadContext()
        {
            if (context == null)
            {
                String contextLocation = defaultContextLocationBuilder.build(GetType());

                try
                {
                    context = new BeanohApplicationContext(contextLocation);
                    context.Refresh();
                }
                catch (ObjectDefinitionParsingException e)
                {
                    throw e;
                }
                catch (ObjectDefinitionStoreException e)
                {
                    throw new MissingConfigurationException("Unable to load "
                            + contextLocation + ".", e);
                }

            }
        }

        protected class ObjectDefinitionGetter : IObjectDefinitionAction
        {
            BeanohTestCase outerObject;
            public ObjectDefinitionGetter(BeanohTestCase outerObject)
            {
                this.outerObject = outerObject;
            }
            public void Execute(String Name, IObjectDefinition Definition)
            {
                this.outerObject.context.GetObject(Name);
            }
        }


    }
}
