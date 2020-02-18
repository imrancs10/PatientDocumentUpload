using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.Data.Entity;
using PatientReport.Global;
using PatientReport.Models.Masters;

namespace PatientReport.BAL.Masters
{
    public class DocumentDetails
    {
        PatientPortalEntities _db = null;

        public Enums.CrudStatus SaveDocumentDetail(PatientDocument document)
        {
            _db = new PatientPortalEntities();
            int _effectRow = 0;
            var _documentRow = _db.PatientDocuments.Where(x => x.DocumentTitle.Equals(document.DocumentTitle)).FirstOrDefault();
            if (_documentRow == null)
            {
                _db.Entry(document).State = EntityState.Added;
                _effectRow = _db.SaveChanges();
                return _effectRow > 0 ? Enums.CrudStatus.Saved : Enums.CrudStatus.NotSaved;
            }
            else
                return Enums.CrudStatus.DataAlreadyExist;
        }

        public List<PatientDocument> GetAllDocumentDetail(string crNumber)
        {
            _db = new PatientPortalEntities();
            var _documentRow = _db.PatientDocuments.Where(x => x.CRNumber == crNumber).ToList();
            if (_documentRow.Count > 0)
            {
                return _documentRow;
            }
            return null;
        }
        public bool DeleteHospitalDetail(int Id)
        {
            _db = new PatientPortalEntities();
            var _hospitalRow = _db.HospitalDetails.Where(x => x.Id == Id).FirstOrDefault();
            if (_hospitalRow != null)
            {
                _db.HospitalDetails.Remove(_hospitalRow);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}