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
using Spring.Context.Support;
using Spring.Objects.Factory.Xml;
using Castle.DynamicProxy;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Config;
using SourceAllies.Beanoh.Exception;
#endregion

namespace SourceAllies.Beanoh.Spring.Wrapper
{
    /// <summary>
    /// Wraps XML context loading in order to track loaded object definitions. This information is 
    /// used to determine if duplicate object definitions have been loaded.
    /// </summary>
    /// <author>Akrem Saed</author>
    public class BeanohApplicationContext : XmlApplicationContext 
    {
        private IList<BeanohObjectFactoryMethodInterceptor> callbacks;

        public BeanohApplicationContext(String configLocation)
            : base(false, "beanohAppContext", true, null, 
            new String[] { configLocation, "assembly://Beanoh/SourceAllies.Beanoh.Spring/Base-BeanohContext.xml" })
        {
            // TODO add an embedded data source in assembly://Beanoh/SourceAllies.Beanoh.Spring/Base-BeanohContext.xml
            
            callbacks = new List<BeanohObjectFactoryMethodInterceptor>();
        }

        protected override void LoadObjectDefinitions(DefaultListableObjectFactory  objectFactory)
        {
            callbacks.Add(new BeanohObjectFactoryMethodInterceptor(objectFactory));
            ProxyGenerator generator = new ProxyGenerator();
            DefaultListableObjectFactory wrapper = (DefaultListableObjectFactory)generator.CreateClassProxy(objectFactory.GetType(), callbacks.ToArray());
            base.LoadObjectDefinitions(wrapper);
        }

       
        public void AssertUniqueObjects(ISet<String> ignoredDuplicateObjectNames)
        {
            
            foreach (BeanohObjectFactoryMethodInterceptor callback in callbacks) 
            {
			IDictionary<string, IList<IObjectDefinition>> objectDefinitionMap = callback.ObjectDefinitionMap;
			foreach (string key in objectDefinitionMap.Keys) {
				if (!ignoredDuplicateObjectNames.Contains(key)) {
					IList<IObjectDefinition> definitions = objectDefinitionMap[key];
					IList<string> resourceDescriptions = new List<string>();
					foreach (IObjectDefinition definition in definitions) 
                    {
						String resourceDescription = definition.ResourceDescription;
						if (resourceDescription == null) 
                        {
							resourceDescriptions.Add(definition.ObjectTypeName);
						} 
                        else if (!resourceDescription.EndsWith("-BeanohContext.xml]")) 
                        {
							if(!resourceDescriptions.Contains(resourceDescription))
                            {
								resourceDescriptions.Add(resourceDescription);
							}
						}
					}
					
                    if (resourceDescriptions.Count > 1) 
                    {
						throw new DuplicateObjectDefinitionException("Object '"
								+ key + "' was defined "
								+ resourceDescriptions.Count + " times." 
                                + Environment.NewLine
                                + "Either remove duplicate object definitions or ignore them with the 'IgnoreDuplicateObjectNames' method." 
                                + Environment.NewLine
								+ "Configuration locations:"
								+ MessageUtil.list(resourceDescriptions));
					}
				}
			}
		}
        }
    }
}
