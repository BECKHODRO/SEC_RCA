using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using GASEC_RCA.Data;
using GASEC_RCA.Service;

namespace GASEC_RCA.Data
{
    public class ExportService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ExportService(IWebHostEnvironment hostingEnvironment)
        {
            _hostEnvironment = hostingEnvironment;
        }

        ActesNaissService acteNaissanceService = new ActesNaissService();
        //ActesDeNaissance actesDeNaissance = new ActesDeNaissance();

        public MemoryStream CreatePDF(int? id)
        {

            acteNaissanceService.GetActesDeNaissanceByID(id);
            

            PdfDocument document = new PdfDocument();
            PdfPage currentPage = document.Pages.Add();
            SizeF clientSize = currentPage.GetClientSize();
            FileStream imageStream = new FileStream(_hostEnvironment.WebRootPath + "//images//pdf//image002.JPG", FileMode.Open, FileAccess.Read);
            PdfImage icon = new PdfBitmap(imageStream);
            SizeF iconSize = new SizeF(40, 40);
            PointF iconLocation = new PointF(clientSize.Width - 265, 0);
            PdfGraphics graphics = currentPage.Graphics;
            graphics.DrawImage(icon, iconLocation, iconSize);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            var headerText = new PdfTextElement("REPUBLIQUE CENTRAFRICAINE", font, new PdfSolidBrush(Color.FromArgb(0, 0, 67, 0)));
            headerText.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            PdfLayoutResult result = headerText.Draw(currentPage, new PointF(clientSize.Width - 245, iconLocation.Y + 50));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
            headerText = new PdfTextElement("Unité-Dignité-Travail", font);
            result = headerText.Draw(currentPage, new PointF(clientSize.Width - 290, result.Bounds.Bottom + 5));
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

            headerText = new PdfTextElement("----------", font);

            //headerText = new PdfTextElement(string.Format("{0}, {1}", "398 W Broadway, Evanston Ave Fargo,", "\nNorth Dakota, 10012"), font);
            result = headerText.Draw(currentPage, new PointF(clientSize.Width - 260, result.Bounds.Bottom + 5));

            headerText = new PdfTextElement("ACTE DE NAISSANCE N° : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_NUM"].ToString(), font);

            //headerText = new PdfTextElement(string.Format("{0}, {1}", "398 W Broadway, Evanston Ave Fargo,", "\nNorth Dakota, 10012"), font);
            result = headerText.Draw(currentPage, new PointF(clientSize.Width - 332, result.Bounds.Bottom + 5));


            //font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
            //headerText = new PdfTextElement("Invoice No.#23698720", font);
            //headerText.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            //headerText.Draw(currentPage, new PointF(clientSize.Width - 25, result.Bounds.Y + 20));

            // Début partie grille

            PdfGrid grid = new PdfGrid();
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
            grid.Style.Font = font;
            grid.Columns.Add(3);
            //grid.Columns[0].Width = 170;
            grid.Columns[1].Width = 20;
            grid.Columns[2].Width = 300;
            //grid.Columns[3].Width = 70;

            //grid.Headers.Add(1);
            //PdfStringFormat stringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            //PdfGridRow header = grid.Headers[0];

            //header.Cells[0].Value = "Colonne 1";
            //header.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
            //header.Cells[1].Value = "Colonne 2";
            //header.Cells[1].StringFormat = stringFormat;
            //header.Cells[2].Value = "Rate($)";
            //header.Cells[2].StringFormat = stringFormat;
            //header.Cells[3].Value = "Amount($)";
            //header.Cells[3].StringFormat = stringFormat;

            //PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            //cellStyle.Borders.All = PdfPens.Transparent;
            //cellStyle.TextBrush = PdfBrushes.White;
            //cellStyle.BackgroundBrush = new PdfSolidBrush(Color.FromArgb(255, 255, 255, 255));

            //for (int j = 0; j < header.Cells.Count; j++)
            //{
            //    PdfGridCell cell = header.Cells[j];
            //    cell.Style = cellStyle;
            //}

            PdfGridRow row = grid.Rows.Add();
            row.Cells[0].Value = "Marié(e) le : 22/12/1990.............................";
            row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
            //row.Cells[0].Value = "Marié(e) le :";
            row.Cells[0].Style.BackgroundBrush = new PdfSolidBrush(Color.FromArgb(1, 255, 255, 255));

            row.Cells[2].Value = "Région : "+ acteNaissanceService.dtListeActeNaissance.Rows[0]["REG_NOM"].ToString() + "..........";
            //row.Cells[1].StringFormat = stringFormat;

            row = grid.Rows.Add();
            row.Cells[0].Value = "Acte n°: 5656545.............................................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Préfecture : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["PRF_NOM"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Dressé à :...................................................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Sous-préfecture : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["SP_NOM"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Options :.....................................................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Commune : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["CMN_NOM"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Le : .........................................................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Arrondissemnt : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ARRDT_NOM"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Officier d'état civil : Emile Gros Raymond NAKOMBO............";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Centre d'etat civil : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["CEC_NOM"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Divorcé (e) le : 10/10/2010...................................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Le (lettre) : "+ 
                acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_DATE_NAISS"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Jugement N° : 235412 du : 11/15/2014..........................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "A été déclarée la naissance d'un enfant de sexe : " + 
                acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_SEXE"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "Rendu par :............................" +
                "Le..................";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Né(e) le (Lettre) : " +
				acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_DATE_NAISS"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "L'Officier d'état civil";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Heure : "+ acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_HEURE_NAISS"].ToString() + " minutes .....";

            row = grid.Rows.Add();
            row.Cells[0].Value = "Déclaration de paternité homologué" +
                "\n par jugement n°.........du........"+
                " rendu par Le............ ";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "A : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_LIEU_NAISS"].ToString() + "..........";

			row = grid.Rows.Add();
            row.Cells[0].Value = "L’Officier d’état civil";
            //row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

            row.Cells[2].Value = "Nom (s) : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["PERS_NOM"].ToString() + "..........";

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Prénom (s) : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["PERS_PRENOM"].ToString() + "..........";

			//row = grid.Rows.Add();
			//row.Cells[0].Value = "L’Officier d’état civil";
			////row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			//row.Cells[2].Value = "Né le : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["PERS_DATE_NAISS"].ToString()+
   //             " à " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_HEURE_NAISS"].ToString();

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Fils, fille de : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_NOM_COMPLET_PERE"].ToString() + "..........";

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Né le : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_DATE_NAISS_PERE"].ToString() +
                "\n à.."+ acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_LIEU_NAISS_PERE"].ToString() + "..........";

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Nationalité : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_NATIONALITE_PERE"].ToString() + "..........";


			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Profession : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_PROFESSION_PERE"].ToString() + "..........";

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Domicilié à : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_DOMICILE_PERE"].ToString() + "..........";


			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Et de : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_NOM_COMPLET_MERE"].ToString() + "..........";

			row.Cells[2].Value = "Né le : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_DATE_NAISS_MERE"].ToString() +
				"\n à.." + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_LIEU_NAISS_MERE"].ToString() + "..........";

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Nationalité : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_NATIONALITE_MERE"].ToString() + "..........";


			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Profession : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_PROFESSION_MERE"].ToString() + "..........";

			row = grid.Rows.Add();
			row.Cells[0].Value = "L’Officier d’état civil";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

			row.Cells[2].Value = "Domiciliée à : " + acteNaissanceService.dtListeActeNaissance.Rows[0]["ACT_DOMICILE_MERE"].ToString() + "..........";





			//row.Cells[2].StringFormat = stringFormat;

			//decimal amount = (decimal)(25 * 24.46);
			//row.Cells[3].Value = String.Format("{0:0.##}", amount);
			//row.Cells[3].StringFormat = stringFormat;

			//decimal sum = 0;
			//sum += amount;

			//row = grid.Rows.Add();
			//row.Cells[0].Value = "Desktop Software Development";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
			//row.Cells[1].Value = $"{25}";
			//row.Cells[1].StringFormat = stringFormat;
			//row.Cells[2].Value = $"{47.83}";
			//row.Cells[2].StringFormat = stringFormat;
			//amount = (decimal)(25 * 47.83);
			//row.Cells[3].Value = String.Format("{0:0.##}", amount);
			//row.Cells[3].StringFormat = stringFormat;

			//sum += amount;

			//row = grid.Rows.Add();
			//row.Cells[0].Value = "Site admin development";
			//row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
			//row.Cells[1].Value = $"{33}";
			//row.Cells[1].StringFormat = stringFormat;
			//row.Cells[2].Value = $"{85.1}";
			//row.Cells[2].StringFormat = stringFormat;
			//amount = (decimal)(33 * 85.1);
			//row.Cells[3].Value = String.Format("{0:0.##}", amount);
			//row.Cells[3].StringFormat = stringFormat;

			//sum += amount;

			grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.PlainTable3);
            PdfGridStyle gridStyle = new PdfGridStyle();
            gridStyle.CellPadding = new PdfPaddings(5, 5, 5, 5);
            grid.Style = gridStyle;

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            result = grid.Draw(currentPage, 14, result.Bounds.Bottom + 30, clientSize.Width - 35, layoutFormat);

            //currentPage.Graphics.DrawRectangle(new PdfSolidBrush(Color.FromArgb(255, 239, 242, 255)),
            //    new RectangleF(result.Bounds.Right - 100, result.Bounds.Bottom + 20, 100, 20));

            //PdfTextElement element = new PdfTextElement("Total", font);
            //element.Draw(currentPage, new RectangleF(result.Bounds.Right - 100, result.Bounds.Bottom + 22, result.Bounds.Width, result.Bounds.Height));

            //var totalPrice = $"$ {Math.Round(sum, 2)}";
            //element = new PdfTextElement(totalPrice, font);
            //element.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            //element.Draw(currentPage, new RectangleF(15, result.Bounds.Bottom + 22, result.Bounds.Width, result.Bounds.Height));

            // Fin partie grille

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            stream.Position = 0;

            return stream;
        }
    }
}
