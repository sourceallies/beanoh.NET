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
    /// Utiltiy class to assist with producing meaningful text messages
    /// </summary>
    /// <author>Akrem Saed</author>
    class MessageUtil
    {
        /// <summary>
        /// Separates messages into lines
        /// </summary>
        public static string list(IList<string> messages) 
        {
		    IList<string> sortedComponents = new List<string>(messages);
            sortedComponents.OrderBy(s => s);
		    string output = "";
		    foreach (string component in sortedComponents) 
            {
                output += Environment.NewLine + component;
		    }
		    return output;
	    }
    }
}
