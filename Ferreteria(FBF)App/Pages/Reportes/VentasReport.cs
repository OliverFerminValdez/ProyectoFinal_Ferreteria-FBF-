﻿using Ferreteria_FBF_App.BLL;
using Ferreteria_FBF_App.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Pages
{
    public class VentasReport
    {
        #region Declaration
        int maxColumn = 8;
        Document document;
        PdfPTable pdfPTable = new PdfPTable(8);
        PdfPCell pdfCell;
        Font fontStyle;
        Font fontFecha;
        Font Titulo;
        MemoryStream memoryStream = new MemoryStream();
        List<Ventas> lista = new List<Ventas>();
        #endregion

        public byte[] Report(List<Ventas> Ventas)
        {
            lista = Ventas;

            document = new Document(PageSize.Letter, 25f, 25f, 20f, 30f);
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Calibri", 8f, 1);
            PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            float[] sizes = new float[maxColumn];

            for (int i = 0; i < maxColumn; i++)
            {
                if (i == 0) sizes[i] = 100;
                else sizes[i] = 100;

            }

            pdfPTable.SetWidths(sizes);

            this.ReportHeader();
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


            pdfCell = new PdfPCell(this.setPageTitle());
            pdfCell.Colspan = maxColumn;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);

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

            pdfCell = new PdfPCell(new Phrase("Reporte de Ventas", fontStyle));
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
            pdfCell = new PdfPCell(new Phrase("ID", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Cliente", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);


            pdfCell = new PdfPCell(new Phrase("Fecha", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);


            pdfCell = new PdfPCell(new Phrase("Tipo", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("SubTotal", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("ITBIS", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Descuentos", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Total General", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();
            #endregion

            #region Table Body
            int num = 0;
            double TotalGeneral = 0;
            double ITBIS = 0;


            foreach (var item in lista)
            {
                TotalGeneral += item.TotalGeneral;
                ITBIS += item.ITBIS;
                num++;
                pdfCell = new PdfPCell(new Phrase(item.VentaId.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase((ClientesBLL.Buscar(item.ClienteId).Nombre +" "+ ClientesBLL.Buscar(item.ClienteId).Apellido), _fontStyle)) ;
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);


                pdfCell = new PdfPCell(new Phrase(item.Fecha.ToString("dd/MM/yyyy"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);


                pdfCell = new PdfPCell(new Phrase(item.Tipo, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Total.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.ITBIS.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Descuentos.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.TotalGeneral.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);

                pdfPTable.CompleteRow();

            }

            pdfCell = new PdfPCell(new Phrase(num++.ToString(), fontStyle));
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

            pdfCell = new PdfPCell(new Phrase(ITBIS.ToString(), fontStyle));
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

            pdfCell = new PdfPCell(new Phrase(Math.Round(TotalGeneral,2).ToString(), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;

            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();
            #endregion
        }

    }
}