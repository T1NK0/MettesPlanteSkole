using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MettesPlanteskole
{
    internal class Kurv
    {
        private DataTable _kurv;
        public Kurv()
        {
            if (HttpContext.Current.Session["kurv"] != null)
            {
                _kurv = (DataTable)HttpContext.Current.Session["kurv"];
            }
            else
            {
                TagKurv();
            }
        }
        private void TagKurv()
        {
            _kurv = new DataTable();
            _kurv.Columns.Add("varenummer", typeof(string));
            _kurv.Columns.Add("antal", typeof(int));
            _kurv.Columns.Add("pris", typeof(decimal));
            _kurv.Columns.Add("varenavn", typeof(string));
            _kurv.Columns.Add("SamletPris", typeof(decimal));
            _kurv.Columns.Add("produktid", typeof(int));
            GemKurv();
        }

        private void GemKurv()
        {
            HttpContext.Current.Session["kurv"] = _kurv;
        }

        public void PutiKurv(string varenummer, int antal, decimal pris, string varenavn, int produktid)
        {
            bool addnew = true;
            foreach (DataRow row in _kurv.Rows)
            {
                if (row["varenummer"].ToString() == varenummer)
                {
                    RetVare(varenummer, Convert.ToInt32(row["antal"]) + antal);
                    addnew = false;
                }
            }
            if (addnew)
            {
                DataRow row = _kurv.NewRow();
                row["varenummer"] = varenummer;
                row["antal"] = antal;
                row["pris"] = pris;
                row["varenavn"] = varenavn;
                row["SamletPris"] = antal * pris;
                row["produktid"] = produktid;
                _kurv.Rows.Add(row);
            }
        }

        public void RetVare(string varenummer, int antal)
        {
            foreach (DataRow row in _kurv.Rows)
            {
                if (row["varenummer"].ToString() == varenummer)
                {
                    row["antal"] = antal;
                    row["SamletPris"] = (decimal)row["pris"] * antal;
                }
            }
        }

        public void SletVare(string varenummer)
        {
            foreach (DataRow row in _kurv.Rows)
            {
                if (row["varenummer"].ToString() == varenummer)
                {
                    row.Delete();
                    break;
                }
            }
            _kurv.AcceptChanges();
        }

        public void Afslut()
        {
            _kurv.Dispose();
            _kurv.AcceptChanges();
        }

        public void PutiKurv(string p1, string p2)
        {
            throw new NotImplementedException();
        }

        public decimal prisIalt(decimal samletpris)
        {
            decimal prisIalt = 0;
            foreach (DataRow row in _kurv.Rows)
            {
                prisIalt += (decimal)row["SamletPris"];
            }
            return prisIalt;
        }

        public DataTable get_kurv()
        {
            return _kurv;
        }

        public decimal moms(decimal samletpris)
        {
            decimal moms = 0;
            moms = (prisIalt(samletpris) / 100) * 25;
            return moms;
        }
    }
}