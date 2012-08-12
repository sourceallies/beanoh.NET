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
using System.Runtime.ExceptionServices;
using Spring.Context.Support;
#endregion

namespace SourceAllies.Beanoh.Exception
{
    /// <summary>
    /// Exception that is thrown when Beanoh.NET cannot load Spring.NET context resources
    /// </summary>
    /// <author>Akrem Saed</author>
   public class MissingConfigurationException : System.ApplicationException
    {
    
       public MissingConfigurationException() 
            : base() 
        { }
       
       public MissingConfigurationException(string message) 
            : base(message) 
        { }
       
       public MissingConfigurationException(string message, System.Exception inner) 
            : base(message, inner) 
        { }

        protected MissingConfigurationException(
            System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) 
        { }

    }
}
