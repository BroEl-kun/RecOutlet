using System;
using ceTe.DynamicPDF;
//using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace RecOutletWarehouse.WebForms {

    //public partial class POReport : System.Web.UI.Page { //debug purposes only
    //    protected void Page_Load(object sender, EventArgs e){
    //        Document document = new Document();
    //        string id = Request.QueryString["id"];
    //        string outstring = "ID is " + id;
    //        ceTe.DynamicPDF.Page page = new ceTe.DynamicPDF.Page();
    //        page.Elements.Add( new Label(outstring, 0, 0, 100, 12, Font.Helvetica, 12 ) );
    //        document.Pages.Add( page );
    //        document.DrawToWeb();

    //    }
    //}

    public partial class POReport : DplxWebForm {
        protected void Page_Load(object sender, EventArgs e) {
            //if (IsPostBack) {
            long poid = Convert.ToInt64(Request.QueryString["id"]);
            string outputFile = "PO_" + poid.ToString();
            Parameters.Add("POID", poid);
            DrawPdfToWeb(outputFile);
            //}
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e) {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
        }
        #endregion
    }
}