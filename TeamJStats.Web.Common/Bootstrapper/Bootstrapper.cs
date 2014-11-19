using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamJStats.Web.Common.App_Start;

namespace TeamJStats.Web.Common.Bootstrapper
{
    public class Bootstrapper
    {
        #region Constants and Fields

        private readonly IEnumerable<IBootstrapTask> _tasks;

        #endregion

        #region Constructors and Destructors

        public Bootstrapper(IEnumerable<IBootstrapTask> tasks)
        {
            _tasks = tasks;
        }

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            foreach (IBootstrapTask task in _tasks.OrderBy(x => x.Priority))
            {
                task.Execute();
            }
        }

        #endregion

        public static void ConfigureApplication()
        {
            StructuremapMvc.Start();
            var bootstrapper = DependencyResolver.Current.GetService<Bootstrapper>();
            bootstrapper.Initialize();

        }
    }
}