// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using TeamJStats.DataAccess.DataAccess;
using TeamJStats.Web.Common.Bootstrapper;

namespace TeamJStats.Web.Common.DependencyResolution {
    using StructureMap.Configuration.DSL;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.Assembly("TeamJStats.Services");
                    scan.Assembly("TeamJStats.Web");
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                    scan.AddAllTypesOf<IBootstrapTask>();
                });
            For<IDataContextFactory>().Use<DataContextFactory>();
//            For(typeof(IRepository<>)).Use(typeof(Repository<>));
//            For<IUnitOfWork>().Use<UnitOfWork>();
        }

        #endregion
    }
}