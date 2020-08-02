using Ferreteria_FBF_App.BLL;
using Ferreteria_FBF_App.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Pages.Reportes
{
    public class FacturaDeCompra
    {
        #region Declaration
        int maxColumn = 6;
        Document document;
        PdfPTable pdfPTable = new PdfPTable(6);
        PdfPCell pdfCell;
        Font fontStyle;
        Font fontFecha;
        Font Titulo;
        MemoryStream memoryStream = new MemoryStream();
        Inventario inv = new Inventario();
        int usuariologueadoId;
        #endregion

        public byte[] Report(Inventario inventario, int userID)
        {
            usuariologueadoId = userID;
            inv = inventario;
            document = new Document(PageSize.Letter, 25f, 25f, 20f, 30f);
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Calibri", 8f, 1);
            PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            float[] sizes = new float[maxColumn];

            for (int i = 0; i < maxColumn; i++)
            {
                if (i == 0) sizes[i] = 50;
                else sizes[i] = 100;

            }

            pdfPTable.SetWidths(sizes);

            this.ReportHeader();
            this.FacturaHeader();
            this.ReportBody();

            pdfPTable.HeaderRows = 1;
            document.Add(pdfPTable);
            document.Close();

            return memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            pdfCell = new PdfPCell(this.AddLogo());
            pdfCell.Colspan = 1;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            //pdfCell = new PdfPCell(this.AddId());
            //pdfCell.Colspan = 1;
            //pdfCell.Border = 0;
            //pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(this.setPageTitle());
            pdfCell.Colspan = maxColumn;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

        }
        public PdfPTable AddId()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            pdfCell = new PdfPCell(new Phrase(VentasBLL.GetList(p => true).Count.ToString(), fontFecha));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }
        public void FacturaHeader()
        {
            PdfPTable pdfPTable = new PdfPTable(4);

            pdfPTable.CompleteRow();
        }

        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            string img = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Resources\LogoReport2.png"}";
            Image image = Image.GetInstance(img);

            pdfCell = new PdfPCell(image);
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private PdfPTable setPageTitle()
        {
            int maxColumn = 2;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            fontStyle = FontFactory.GetFont("Calibri", 18f, 1);
            fontFecha = FontFactory.GetFont("Calibri", 10f, 1);
            Titulo = FontFactory.GetFont("Calibri", 25f, 1);

            pdfCell = new PdfPCell(new Phrase("Ferreteria FBF", Titulo));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();
            if (inv.InventarioId == 0)
                pdfCell = new PdfPCell(new Phrase("No:  " + VentasBLL.GetList(p => true).Count.ToString(), fontFecha));
            else
                pdfCell = new PdfPCell(new Phrase("No:  " + inv.InventarioId, fontFecha));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase("Entrada de inventario", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase(DateTime.Now.ToString("MM/dd/yyyy H:mm tt"), fontFecha));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }
        private void ReportBody()
        {
            fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            var _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);

            #region Table Header
            pdfCell = new PdfPCell(new Phrase("No.     ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Descripcion", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);


            pdfCell = new PdfPCell(new Phrase("Marca", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);


            pdfCell = new PdfPCell(new Phrase("Cantidad", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Costo", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Importe", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();
            #endregion

            #region Table Body
            int num = 0;

            foreach (var item in inv.Productos)
            {
                num++;
                pdfCell = new PdfPCell(new Phrase(num.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(ProductosBLL.Buscar(item.ProductoId).Descripción, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(MarcasBLL.Buscar(ProductosBLL.Buscar(item.ProductoId).MarcaId).Descripcion.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Inventario.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.costo.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase((item.costo * item.Inventario).ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfPTable.CompleteRow();

            }
            TableRows("", "", fontStyle, "");
            TableRows("", "", fontStyle, "");
            TableRows("", "", fontStyle, "");
            TableRows("", "", fontStyle, "");
            Totales("Total: ", inv.TotalInventario.ToString(), "", "", _fontStyle);
            TableRows("", "", fontStyle, "");
            TableRows("", "", fontStyle, "");

            if (SuplidoresBLL.Buscar(inv.SuplidorId) != null)
                Totales("Usuario: ", (UsuariosBLL.Buscar(inv.UsuarioId).Nombre + " " + UsuariosBLL.Buscar(inv.UsuarioId).Apellido), "Suplidor: ", SuplidoresBLL.Buscar(inv.SuplidorId).Nombre, _fontStyle);/*+ UsuariosBLL.Buscar(venta.UsuarioId).Nombre + " " + UsuariosBLL.Buscar(venta.UsuarioId).Apellido, fontStyle, ""*/
            else
                Totales("Despachado por:", (UsuariosBLL.Buscar(usuariologueadoId).Nombre + " " + UsuariosBLL.Buscar(usuariologueadoId).Apellido), "Suplidor: ", SuplidoresBLL.Buscar(inv.SuplidorId).Nombre, _fontStyle);
            #endregion
        }
        public void Totales(string num, string col2, string total, string restotal, Font _fontStyle)
        {
            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(num, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(col2, _fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(total, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            if (total == "") { pdfCell.Border = 0; }
            pdfCell.BackgroundColor = BaseColor.White;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(restotal, _fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            if (restotal == "") { pdfCell.Border = 0; }
            pdfCell.BackgroundColor = BaseColor.White;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();
        }

        public void TableRows(string num, string col2, Font fontStyle, string total)
        {
            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(num, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(col2, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(total, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();
        }
    }
}
