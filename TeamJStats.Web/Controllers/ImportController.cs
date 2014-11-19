using System;
using System.Web.Mvc;
using TeamJStats.DataAccess.DataAccess;
using TeamJStats.Services;

namespace TeamJStats.Web.Controllers
{
    public class ImportController : ControllerBase
    {
        private readonly IImportService _importService;
        private readonly IDataContextFactory _contextFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ImportController(IImportService importService, IDataContextFactory contextFactory)
        {
            _importService = importService;
            _contextFactory = contextFactory;
//            _unitOfWork = unitOfWork;
        }

        public ActionResult Teams()
        {
            var teams = _importService.GetTeams();
            return Json(teams, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BoxScores(DateTime? date = null)
        {
            var eventDate = date ?? DateTime.Now;
            _importService.GetBoxScores(eventDate);

            return null;
        }
    }
}