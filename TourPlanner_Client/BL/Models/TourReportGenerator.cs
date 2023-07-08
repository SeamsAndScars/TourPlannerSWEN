using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Layout;
using iText.Layout.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Layout;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using TourPlanner_Client.Models;
using System.Windows;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using TourPlanner_Client.Converters;
using System.Windows.Data;
using System.Globalization;

namespace TourPlanner_Client.BL.Models
{
    public class TourReportGenerator
    {
        
        public static void GenerateReport(Tour tour, int popularity, string childFriendlinessLabel)
        {
            string outputPath = $"TourReport_{tour.Name}.pdf";
            try
            {
                IValueConverter converter = new SecondsToTimeConverter();

                // Create a new PDF document
                using (PdfWriter writer = new PdfWriter(outputPath))
                using (PdfDocument pdfDoc = new PdfDocument(writer))
                using (Document document = new Document(pdfDoc))
                {
                    // Add the tour information to the document
                    document.Add(new Paragraph("Tour Report").SetBold().SetFontSize(18).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    document.Add(new Paragraph().Add(new Text("Name: ").SetBold()).Add(tour.Name));
                    document.Add(new Paragraph().Add(new Text("Description: ").SetBold()).Add(tour.Description));
                    document.Add(new Paragraph().Add(new Text("Source: ").SetBold()).Add(tour.Source));
                    document.Add(new Paragraph().Add(new Text("Destination: ").SetBold()).Add(tour.Destination));
                    document.Add(new Paragraph().Add(new Text("Estimated time: ").SetBold()).Add((string)converter.Convert(tour.Estimate, typeof(string), null, CultureInfo.CurrentCulture)));
                    document.Add(new Paragraph().Add(new Text("Distance: ").SetBold()).Add(tour.Distance.ToString()));
                    document.Add(new Paragraph().Add(new Text("Tour type: ").SetBold()).Add(tour.Ttype.ToString()));
                    document.Add(new Paragraph().Add(new Text("Popularity: ").SetBold()).Add(popularity.ToString()));
                    document.Add(new Paragraph().Add(new Text("Child-Friendliness: ").SetBold()).Add(childFriendlinessLabel));

                    Image image = new Image(ImageDataFactory.Create($"Images/{tour.ImageFileName}"));
                    document.Add(image);

                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph(" "));

                    // Add the tour logs to the document
                    document.Add(new Paragraph("Tour Logs").SetBold().SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                    Table table = new Table(5);

                    // Add table headers

                    
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Date").SetBold()));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Difficulty").SetBold()));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Time").SetBold()));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Rating").SetBold()));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Comment").SetBold()));

                    // Add data rows to the table
                    foreach (TourLog tourLog in tour.TourLogs)
                    {
                        table.AddCell(tourLog.Date.ToString("dd.MM.yyyy"));
                        table.AddCell(tourLog.Difficulty.ToString());
                        table.AddCell(tourLog.Time);
                        table.AddCell(tourLog.Rating.ToString());
                        table.AddCell(tourLog.Comment);
                    }

                    // Add the table to the document
                    table.SetWidth(UnitValue.CreatePercentValue(100));
                    document.Add(table);
                }

                MessageBox.Show($"Report generated successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}");
            }
        }
    }
}
