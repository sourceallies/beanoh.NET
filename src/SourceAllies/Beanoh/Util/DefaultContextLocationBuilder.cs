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
using Common.Logging;
#endregion


namespace SourceAllies.Beanoh.Util
{
    /// <summary>
    ///  Builds the context location of the bootstrap context.
    /// </summary>
    /// <author>David Kessler</author>
    /// <author>Akrem Saed (.NET)</author>
    class DefaultContextLocationBuilder
    {
        private static ILog LOGGER = LogManager.GetLogger(typeof(DefaultContextLocationBuilder));

        public String build(Type type)
        {
            LOGGER.Debug("assembly fullname is : " + type.Assembly.GetName().Name);
            LOGGER.Debug("namespace : " + type.Namespace.ToString());
            LOGGER.Debug(" type name : " + type.Name);

            StringBuilder builder = new StringBuilder();

            /*
            builder.Append("assembly://");
            builder.Append(type.Assembly.GetName().Name);
            builder.Append(type.Namespace);
            builder.Append("/");
            builder.Append(type.Name);
            builder.Append("-BeanohContext.xml");
            */

            // TODO come up with a suitable convetion for location of config file location that works for assemblies and ordninary projects
            builder.Append("file://");
            builder.Append(type.Name);
            builder.Append("-BeanohContext.xml");
            LOGGER.Debug(builder.ToString());

            return builder.ToString();
        }

    }
}
