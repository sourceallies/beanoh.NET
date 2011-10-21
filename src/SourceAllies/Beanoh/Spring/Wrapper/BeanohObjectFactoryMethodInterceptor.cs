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

#region Importsusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Config;
using Castle.DynamicProxy;
#endregion

namespace SourceAllies.Beanoh.Spring.Wrapper
{
    /// <summary>
    /// A proxy that delegates to a real Spring.net object factory. This collects the arguments that are passed 
    /// to the RegisterObjectDefinition method on the object factory. These object definitions are inspected later by the
    /// BeanohApplicationContext to determine if there are duplicate object definitions.
    /// </summary>
    /// <author>Akrem Saed</author>
    class BeanohObjectFactoryMethodInterceptor : IInterceptor
    {
        private DefaultListableObjectFactory proxiedFactory;
        private System.Type proxiedType;
        private IDictionary<string, IList<IObjectDefinition>> objectDefinitionMap;

        public BeanohObjectFactoryMethodInterceptor ( DefaultListableObjectFactory proxiedFactory) 
        {
		    this.proxiedFactory = proxiedFactory;
            this.proxiedType = proxiedFactory.GetType();
            this.objectDefinitionMap = new Dictionary<string, IList<IObjectDefinition>>();
	    }

        public IDictionary<string, IList<IObjectDefinition>> ObjectDefinitionMap
        {
            get { return objectDefinitionMap; }
        }

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Method.Name;
            object[] arguments = invocation.Arguments;
            if ("RegisterObjectDefinition".Equals(methodName))
            {
                if (objectDefinitionMap.ContainsKey(arguments[0].ToString()))
                {
                    IList<IObjectDefinition> definitions = objectDefinitionMap[arguments[0].ToString()];
                    definitions.Add((IObjectDefinition)arguments[1]);
                }
                else
                {
                    IList<IObjectDefinition> definitions = new List<IObjectDefinition>();
                    definitions.Add((IObjectDefinition)arguments[1]);
                    objectDefinitionMap[(string)arguments[0]] = definitions;
                }
            }

            //use reflection to call the method on the proxied object
            System.Reflection.MethodInfo methodInfo = proxiedType.GetMethod(methodName);
            object methodReturn = methodInfo.Invoke(proxiedFactory, arguments);
        
            //put the real return value into DynamicProxy
            invocation.Proceed();
            invocation.ReturnValue = methodReturn;
        }

        #endregion
    }
}
