using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Services
{
    public class QuestPDFs
    {
        public void RFAeronave(string Imagen, string rutaDestinoPDF)
        {
            var Documento = Document.Create(contenido =>
            {
                contenido.Page(pagina =>
                {
                    pagina.Margin(50);

                    pagina.Content().Border(2).Column(columna =>
                    {
                        columna.Item().PaddingTop(5).Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Height(40).PaddingTop(5).Image(Imagen).FitHeight();
                        });

                        columna.Item().PaddingVertical(5).PaddingHorizontal(60).LineHorizontal(2).LineColor(Colors.Black);

                        columna.Item().Column(columna =>
                        {
                            columna.Item().AlignCenter().Text("TALLER AUTORIZADO D.G.A.C. No. 398").Bold().FontSize(9);
                            columna.Item().AlignCenter().Padding(5).Text("AEROPUERTO NACIONAL PACHUCA HGO HANGAR 14 TEL (771) 7915594").FontSize(7);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().Padding(5).Text("Con esta fecha _____ se recibe la aeronave marca _____ modelo _____ matrícula _____ " +
                                "número de serie _____ marca de motor _____ modelo _____ número de serie _____ procedente de la base en _____ propietario _____.").FontSize(11);
                            columna.Item().Padding(5).Text("Se recibe para realizar servicio de _____ AL MOTOR Y PLANEADOR ______").FontSize(11);

                        });

                        columna.Item().Row(row =>
                        {
                            row.RelativeItem().Padding(5).Text("Entrega de bitácoras actualizadas:").FontSize(11);

                            row.ConstantItem(50).Padding(5).AlignMiddle().AlignCenter().Container().Layers(layers =>
                            {
                                layers.Layer().Canvas((canvas, size) =>
                                {
                                    void DibujarCheck(string color, bool isstroke, bool Check)
                                    {
                                        using var paint = new SKPaint()
                                        {
                                            Color = SKColor.Parse(color),
                                            StrokeWidth = 1,
                                            IsStroke = isstroke,
                                        };

                                        canvas.DrawRoundRect(13, 3, 10, 10, 0, 0, paint);

                                        if (Check)
                                        {
                                            using var textPaint = new SKPaint
                                            {
                                                Color = SKColors.Black, // o cualquier color que prefieras para la paloma
                                                IsAntialias = true,
                                                TextSize = 14, // Ajusta el tamaño del texto según sea necesario
                                                TextAlign = SKTextAlign.Center
                                            };

                                            float textX = 13 + (10 / 2);
                                            float textY = 3 + (17 / 2);
                                            canvas.DrawText("x", textX, textY, textPaint);
                                        }

                                    }

                                    DibujarCheck(Colors.Black, true, true);

                                });

                                layers.PrimaryLayer().Text("SI").FontSize(11);
                            });

                            row.ConstantItem(50).Padding(5).AlignMiddle().AlignCenter().Container().Layers(layer =>
                            {
                                layer.Layer().Canvas((canvas, size) =>
                                {
                                    void DibujarCheck(string color, bool isstroke, bool Check)
                                    {
                                        using var paint = new SKPaint()
                                        {
                                            Color = SKColor.Parse(color),
                                            StrokeWidth = 1,
                                            IsStroke = isstroke,
                                        };

                                        canvas.DrawRoundRect(20, 3, 10, 10, 0, 0, paint);

                                        if (Check)
                                        {
                                            using var textPaint = new SKPaint
                                            {
                                                Color = SKColors.Black, // o cualquier color que prefieras para la paloma
                                                IsAntialias = true,
                                                TextSize = 14, // Ajusta el tamaño del texto según sea necesario
                                                TextAlign = SKTextAlign.Center
                                            };

                                            float textX = 20 + (10 / 2);
                                            float textY = 3 + (17 / 2);
                                            canvas.DrawText("x", textX, textY, textPaint);
                                        }
                                    }

                                    DibujarCheck(Colors.Black, true, true);
                                });

                                layer.PrimaryLayer().Text("NO").FontSize(11);
                            });

                            row.ConstantItem(270).Padding(5).AlignMiddle().Text("Recibo bitácoras: ______").FontSize(11);

                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().Padding(5).Text("Pertenencias Recibidas de la Aeronave y equipo a bordo: ").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });

                        columna.Item().Padding(5).AlignCenter().Background(Colors.Grey.Lighten1).Text("CONDICIONES RECIBIDAS DE LA AERONAVE").FontSize(11);

                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(40).Background(Colors.Grey.Lighten1).Text("Helice:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });


                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(50).Background(Colors.Grey.Lighten1).Text("Motores:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });

                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(140).Background(Colors.Grey.Lighten1).Text("Cabina y Sistema Electrico:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });
                    });
                });

                contenido.Page(pagina =>
                {
                    pagina.Margin(50);
                    pagina.Content().Border(2).Column(columna =>
                    {
                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(110).Background(Colors.Grey.Lighten1).Text("Fuselaje y Empenaje:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });

                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(150).Background(Colors.Grey.Lighten1).Text("Alas y Superficies de Control:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });

                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(100).Background(Colors.Grey.Lighten1).Text("Tren de Aterrizaje:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                        });

                        columna.Item().Padding(5).Row(row =>
                        {
                            row.ConstantItem(200).Background(Colors.Grey.Lighten1).Text("Discrepancias Reportadas Por El Piloto:").FontSize(11);
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);

                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("------------------------------------------------------------------------------------------------------------------------------").FontSize(11);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("                                                                            Entrego                                                             Recibió").FontSize(10);
                            columna.Item().PaddingLeft(5).PaddingTop(0).Text("                                                                   Nombre y firma                                         Nombre y firma").FontSize(10);
                        });
                    });

                });
            });
            Documento.ShowInPreviewer();
            //Documento.GeneratePdf(rutaDestinoPDF);
        }

        public void OrdenTrabajo(string Imagen)
        {
            var Documento = Document.Create(contenido =>
            {
                contenido.Page(pagina =>
                {
                    pagina.Margin(50);
                    pagina.Content().Border(2).Column(columna =>
                    {
                        columna.Item().PaddingTop(5).Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Height(40).PaddingTop(5).Image(Imagen).FitHeight();
                        });

                        columna.Item().PaddingVertical(5).PaddingHorizontal(60).LineHorizontal(2).LineColor(Colors.Black);

                        columna.Item().Column(columna =>
                        {
                            columna.Item().AlignCenter().Text("TALLER AUTORIZADO D.G.A.C. No. 398").Bold().FontSize(9);
                            columna.Item().AlignCenter().Padding(5).Text("AEROPUERTO NACIONAL PACHUCA HGO HANGAR 14 TEL (771) 7915594").FontSize(7);
                        });

                        columna.Item().PaddingLeft(10).Row(row =>
                        {
                            row.RelativeItem().Text("FECHA DE REALIZACION DEL SERVICIO: _____").Bold().FontSize(9);
                            row.RelativeItem().Text("ORDEN DE TRABAJO No. ____").Bold().FontSize(9).FontColor(Colors.Red.Lighten1);
                        });

                        columna.Item().Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().ColumnSpan(4).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("DATOS DE LA AERONAVE").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().Row(2).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MARCA").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MODELO").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MATRICULA").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("No. SERIE").FontSize(8).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);

                            tabla.Cell().Row(4).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T. T.").FontSize(8).Bold();
                            tabla.Cell().Row(4).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.U.R.M").FontSize(8).Bold();
                            tabla.Cell().Row(4).Column(3).ColumnSpan(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("SERVICIO EFECTUADO AL MOTOR Y AL PLANEADOR").FontSize(8).Bold();

                            tabla.Cell().Row(5).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(5).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(5).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(5).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                        });

                        columna.Item().Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().ColumnSpan(5).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("MOTOR 1").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().Row(2).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MARCA").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MODELO").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("No. SERIE").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.T.").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.U.R.M.").FontSize(8).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(3).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);

                            tabla.Cell().Row(4).ColumnSpan(5).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("MOTOR 2").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().Row(5).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MARCA").FontSize(8).Bold();
                            tabla.Cell().Row(5).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MODELO").FontSize(8).Bold();
                            tabla.Cell().Row(5).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("No. SERIE").FontSize(8).Bold();
                            tabla.Cell().Row(5).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.T.").FontSize(8).Bold();
                            tabla.Cell().Row(5).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.U.R.M.").FontSize(8).Bold();

                            tabla.Cell().Row(6).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(6).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(6).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(6).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(6).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);

                            tabla.Cell().Row(7).ColumnSpan(5).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("HELICE  1").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().Row(8).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MARCA").FontSize(8).Bold();
                            tabla.Cell().Row(8).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MODELO").FontSize(8).Bold();
                            tabla.Cell().Row(8).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("No. SERIE").FontSize(8).Bold();
                            tabla.Cell().Row(8).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.T.").FontSize(8).Bold();
                            tabla.Cell().Row(8).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.U.R.M.").FontSize(8).Bold();

                            tabla.Cell().Row(9).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(9).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(9).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(9).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(9).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);

                            tabla.Cell().Row(10).ColumnSpan(5).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("HELICE  2").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().Row(11).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MARCA").FontSize(8).Bold();
                            tabla.Cell().Row(11).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("MODELO").FontSize(8).Bold();
                            tabla.Cell().Row(11).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("No. SERIE").FontSize(8).Bold();
                            tabla.Cell().Row(11).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.T.").FontSize(8).Bold();
                            tabla.Cell().Row(11).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(2).Text("T.U.R.M.").FontSize(8).Bold();

                            tabla.Cell().Row(12).Column(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(12).Column(2).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(12).Column(3).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(12).Column(4).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);
                            tabla.Cell().Row(12).Column(5).Border(0.3f).AlignCenter().AlignMiddle().Padding(6).Text("--------").FontSize(8);


                        });

                        columna.Item().Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                            });

                            tabla.Cell().ColumnSpan(1).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("HELICES").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().ColumnSpan(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(43.5f).Text("-------------------").FontSize(9);

                            tabla.Cell().ColumnSpan(1).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("MOTORES").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().ColumnSpan(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(43.5f).Text("-------------------").FontSize(9);

                            tabla.Cell().ColumnSpan(1).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("CABINA Y SISTEMA ELECTRICO").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().ColumnSpan(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(43.5f).Text("-------------------").FontSize(9);

                            tabla.Cell().ColumnSpan(1).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("FUSELAJE  Y EMPENAJE").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().ColumnSpan(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(43.5f).Text("-------------------").FontSize(9);

                            tabla.Cell().ColumnSpan(1).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("ALAS Y SUPERFICIES DE CONTROL").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().ColumnSpan(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(43.5f).Text("-------------------").FontSize(9);

                            tabla.Cell().ColumnSpan(1).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("TREN DE ATERRIZAJE").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().ColumnSpan(1).Border(0.3f).AlignCenter().AlignMiddle().Padding(43.5f).Text("-------------------").FontSize(9);
                        });

                        columna.Item().Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().ColumnSpan(2).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("RESPONSABLES").FontSize(9).Bold().FontColor("#365F91");
                            tabla.Cell().Row(2).Column(1).Border(0.3f).AlignCenter().PaddingBottom(30).Text("REALIZO").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).AlignCenter().PaddingBottom(30).Text("INSPECCIONO").FontSize(8).Bold();
                        });
                    });
                });
            });
            Documento.ShowInPreviewer();
        }

        public void FormatoComponentesLimitados(string Imagen)
        {
            var Documento = Document.Create(contenido =>
            {
                contenido.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4.Landscape());
                    pagina.Margin(50);
                    pagina.Content().Column(columna =>
                    {
                        columna.Item().PaddingTop(5).Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Height(40).PaddingTop(5).Image(Imagen).FitHeight();
                        });

                        columna.Item().PaddingVertical(5).PaddingHorizontal(60).LineHorizontal(2).LineColor(Colors.Black);

                        columna.Item().Column(columna =>
                        {
                            columna.Item().AlignCenter().Text("TALLER AUTORIZADO D.G.A.C. No. 398").Bold().FontSize(9);
                            columna.Item().AlignCenter().Padding(5).Text("AEROPUERTO NACIONAL PACHUCA HGO HANGAR 14 TEL (771) 7915594").FontSize(7);
                        });

                        columna.Item().Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().ColumnSpan(5).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("COMPONENTES LIMITADOS POR TIEMPO                                                 MATRICULA:").FontSize(11).Bold();
                            tabla.Cell().Row(2).Column(1).Border(0.3f).PaddingLeft(7).Text("MARCA MOTOR").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).PaddingLeft(7).Text("Modelo").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).PaddingLeft(7).Text("No. Serie").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(4).Border(0.3f).PaddingLeft(7).Text("T.T").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(5).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(9).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).PaddingLeft(7).Text("MARCA PLANEADOR").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(2).Border(0.3f).PaddingLeft(7).Text("Modelo").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(3).Border(0.3f).PaddingLeft(7).Text("No. Serie").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(4).Border(0.3f).PaddingLeft(7).Text("T.T").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(5).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(9).Bold();

                            tabla.Cell().Row(4).Column(1).Border(0.3f).PaddingLeft(7).Text("MARCA DE HÉLICE").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(2).Border(0.3f).PaddingLeft(7).Text("Modelo").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(3).Border(0.3f).PaddingLeft(7).Text("No. Serie").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(4).Border(0.3f).PaddingLeft(7).Text("T.T").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(5).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(9).Bold();
                        });

                        columna.Item().PaddingTop(30).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().Row(1).Column(1).Background("#8FAADC").Border(0.3f).PaddingLeft(7).AlignCenter().AlignMiddle().Text("COMPONENTE").FontSize(10).Bold();
                            tabla.Cell().Row(1).Column(2).Background("#8FAADC").Border(0.3f).PaddingLeft(7).AlignCenter().AlignMiddle().Text("MARCA MOTOR").FontSize(10).Bold();
                            tabla.Cell().Row(1).Column(3).Background("#8FAADC").Border(0.3f).PaddingLeft(7).AlignCenter().AlignMiddle().Text("MARCA MOTOR").FontSize(10).Bold();
                            tabla.Cell().Row(1).Column(4).Background("#8FAADC").Border(0.3f).PaddingLeft(7).AlignCenter().AlignMiddle().Text("MARCA MOTOR").FontSize(10).Bold();
                            tabla.Cell().Row(1).Column(5).Background("#8FAADC").Border(0.3f).PaddingLeft(7).AlignCenter().AlignMiddle().Text("MARCA MOTOR").FontSize(10).Bold();


                            tabla.Cell().Row(2).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(2).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(3).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(4).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(4).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(5).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(5).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(5).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(5).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(5).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(6).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(6).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(6).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(6).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(6).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(7).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(7).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(7).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(7).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(7).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(8).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(8).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(8).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(8).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(8).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(9).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(9).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(9).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(9).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(9).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(10).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(10).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(10).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(10).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(10).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();

                            tabla.Cell().Row(11).Column(1).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(11).Column(2).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(11).Column(3).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(11).Column(4).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                            tabla.Cell().Row(11).Column(5).Border(0.3f).PaddingLeft(7).Padding(7).Text("-------------").FontSize(9).Bold();
                        });

                        columna.Item().Column(columna =>
                        {
                            columna.Item().PaddingLeft(7).Text("FORMA 010: REPORTE DE COMPONENTES LIMITADOS POR TIEMPO.").Bold().FontSize(11);
                        });
                    });
                });
            });
            Documento.ShowInPreviewer();
        }

        public void Componentes(string Imagen)
        {
            var Documento = Document.Create(contenido =>
            {
                contenido.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4.Landscape());
                    pagina.Margin(40);
                    pagina.Content().Column(columna =>
                    {
                        columna.Item().PaddingTop(1).Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Height(80).PaddingTop(5).Image(Imagen).FitHeight();
                        });

                        columna.Item().PaddingHorizontal(15).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(120);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().ColumnSpan(10).Background("#C4BC96").Border(0.3f).AlignCenter().AlignMiddle().Text("COMPONENTES LIMITADOS POR TIEMPO                                                 MATRICULA:").FontSize(11).Bold();
                            tabla.Cell().Row(2).Column(1).Border(0.3f).PaddingLeft(7).Text("PLANEADOR MARCA").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).PaddingLeft(7).Text("MODELO").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(4).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(5).Border(0.3f).PaddingLeft(7).Text("SERIE").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(6).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(7).Border(0.3f).PaddingLeft(7).Text("T.T.").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(8).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(9).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(10).Bold();
                            tabla.Cell().Row(2).Column(10).Border(0.3f).PaddingLeft(7).Text("------").FontSize(10).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).PaddingLeft(7).Text("MOTOR 1 MARCA").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(2).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(3).Border(0.3f).PaddingLeft(7).Text("MODELO").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(4).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(5).Border(0.3f).PaddingLeft(7).Text("SERIE").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(6).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(7).Border(0.3f).PaddingLeft(7).Text("T.T.").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(8).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(9).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(10).Bold();
                            tabla.Cell().Row(3).Column(10).Border(0.3f).PaddingLeft(7).Text("------").FontSize(10).Bold();

                            tabla.Cell().Row(4).Column(1).Border(0.3f).PaddingLeft(7).Text("MOTOR 2 MARCA").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(2).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(3).Border(0.3f).PaddingLeft(7).Text("MODELO").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(4).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(5).Border(0.3f).PaddingLeft(7).Text("SERIE").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(6).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(7).Border(0.3f).PaddingLeft(7).Text("T.T.").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(8).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(9).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(10).Bold();
                            tabla.Cell().Row(4).Column(10).Border(0.3f).PaddingLeft(7).Text("------").FontSize(10).Bold();

                            tabla.Cell().Row(5).Column(1).Border(0.3f).PaddingLeft(7).Text("HELICE  1 MARCA").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(2).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(3).Border(0.3f).PaddingLeft(7).Text("MODELO").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(4).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(5).Border(0.3f).PaddingLeft(7).Text("SERIE").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(6).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(7).Border(0.3f).PaddingLeft(7).Text("T.T.").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(8).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(9).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(10).Bold();
                            tabla.Cell().Row(5).Column(10).Border(0.3f).PaddingLeft(7).Text("------").FontSize(10).Bold();

                            tabla.Cell().Row(6).Column(1).Border(0.3f).PaddingLeft(7).Text("HELICE  2 MARCA").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(2).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(3).Border(0.3f).PaddingLeft(7).Text("MODELO").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(4).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(5).Border(0.3f).PaddingLeft(7).Text("SERIE").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(6).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(7).Border(0.3f).PaddingLeft(7).Text("T.T.").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(8).Border(0.3f).PaddingLeft(7).Text("-------").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(9).Border(0.3f).PaddingLeft(7).Text("T.U.R.M.").FontSize(10).Bold();
                            tabla.Cell().Row(6).Column(10).Border(0.3f).PaddingLeft(7).Text("------").FontSize(10).Bold();


                        });

                        columna.Item().PaddingTop(30).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(120);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().Row(1).Column(1).Border(0.3f).Background("#C4BC96").PaddingLeft(7).Text("COMPONENTE").FontSize(11).Bold();
                            tabla.Cell().Row(1).Column(2).Border(0.3f).Background("#C4BC96").PaddingLeft(7).Text("TIEMPO DE REEMPLAZO").FontSize(11).Bold();
                            tabla.Cell().Row(1).Column(3).Border(0.3f).Background("#C4BC96").PaddingLeft(7).Text("ULTIMA APLICACION").FontSize(11).Bold();
                            tabla.Cell().Row(1).Column(4).Border(0.3f).Background("#C4BC96").PaddingLeft(7).Text("PROXIMA APLICACION").FontSize(11).Bold();
                            tabla.Cell().Row(1).Column(5).Border(0.3f).Background("#C4BC96").PaddingLeft(7).Text("REMANENTE").FontSize(11).Bold();



                            tabla.Cell().Row(2).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(2).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(2).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(3).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(3).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(3).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(3).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(4).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(4).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(4).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(4).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(4).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(5).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(5).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(5).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(5).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(5).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(6).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(6).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(6).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(6).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(6).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(7).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(7).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(7).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(7).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(7).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(8).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(8).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(8).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(8).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(8).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();

                            tabla.Cell().Row(9).Column(1).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(9).Column(2).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(9).Column(3).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(9).Column(4).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();
                            tabla.Cell().Row(9).Column(5).Border(0.3f).PaddingLeft(7).PaddingBottom(10).Text("-------").FontSize(12).Bold();


                        });

                        columna.Item().PaddingTop(30).Column(columna =>
                        {
                            columna.Item().PaddingLeft(7).Text("NOTA: LOS TIEMPOS SE TOMARON RESPECTO AL TIEMPO TOTAL DEL PLANEADOR.").Bold().FontSize(11);
                        });

                    });

                    pagina.Footer().PaddingTop(10).Row(row =>
                    {
                        row.RelativeItem().Text(text =>
                        {
                            text.Span("Ing. José Guadalupe Taurino García Parga Responsable de Taller  No. 448").FontSize(9);
                        });

                        row.RelativeItem().AlignCenter().AlignMiddle().Text(text =>
                        {
                            text.Span("Pachuca, Hidalgo a  23 de Octubre  de  2018").FontSize(9);
                        });

                        row.RelativeItem().AlignRight().AlignMiddle().Text(text =>
                        {
                            text.Span("Pagina ");
                            text.CurrentPageNumber().Bold();
                            text.Span(" de ");
                            text.TotalPages().Bold();
                        });
                    });

                });

            });
            Documento.ShowInPreviewer();
        }

        public void StikersEASAPlaneador(string Imagen)
        {
            var Documento = Document.Create(contenido =>
            {
                contenido.Page(pagina =>
                {
                    pagina.Margin(120);
                    pagina.Content().Column(columna =>
                    {
                        columna.Item().Border(2).PaddingTop(5).Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Height(40).PaddingTop(5).PaddingBottom(2).Image(Imagen).FitHeight();
                        });


                        columna.Item().BorderVertical(2).Column(columna =>
                        {
                            columna.Item().AlignCenter().Text("TALLER AUTORIZADO D.G.A.C. No. 398").Bold().FontSize(9);
                            columna.Item().AlignCenter().Text("AEROPUERTO NACIONAL PACHUCA HGO HANGAR 14 TEL (771) 7915594").FontSize(7);
                        });


                        columna.Item().BorderVertical(2).Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().Column(1).Border(0.3f).AlignCenter().AlignMiddle().Text("").FontSize(8).Bold();
                            tabla.Cell().Column(2).Border(0.3f).PaddingLeft(7).Text("FECHA:").FontSize(8).Bold();

                        });

                        columna.Item().BorderVertical(2).BorderBottom(2).Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().Row(1).Column(1).Border(0.3f).Background("#8FAADC").PaddingLeft(7).Text("PLANEADOR:      -----").FontSize(8).Bold();
                            tabla.Cell().Row(1).Column(2).Border(0.3f).PaddingLeft(7).Text("T.T:    ----").FontSize(8).Bold();
                            tabla.Cell().Row(1).Column(3).Border(0.3f).PaddingLeft(7).Text("T.U.R.M:    ---").FontSize(8).Bold();

                            tabla.Cell().Row(2).Column(1).Border(0.3f).PaddingLeft(7).Text("MARCA:    -----").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).PaddingLeft(7).Text("MODELO:   ----").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).PaddingLeft(7).Text("SERIE:   ---").FontSize(8).Bold();

                            tabla.Cell().Row(3).Column(1).Border(0.3f).PaddingLeft(7).Text("MATRICULA:  -----").FontSize(8).Bold();
                            tabla.Cell().Row(3).Column(2).ColumnSpan(2).Border(0.3f).PaddingLeft(7).Text("TIPO: ----").FontSize(8).Bold();

                            tabla.Cell().Row(4).Column(1).ColumnSpan(3).Border(0.3f).Column(columna =>
                            {
                                columna.Item().PaddingLeft(7).Text("CON ESTA FECHA Y HORAS SE EFECTURAON LOS SIGUIENTES TRABAJOS DE MANTENIMIENTO:").FontSize(8);
                                columna.Item().Padding(15).Text(text =>
                                {
                                    text.ParagraphSpacing(2);
                                    text.Line("•  APLICACIÓN DE CARTA DE SERVICIO DE 100 HORAS").FontSize(8);
                                    text.Line("•  LUBRICACION DE CABLES Y POLEAS").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                });
                            });

                            tabla.Cell().Row(5).Column(1).ColumnSpan(3).BorderTop(0.3f).PaddingLeft(7).Text("CERTIFICAMOS QUE LOS TRABAJOS ANTES MENCIONADOS EN LA AERONAVE, PLANEADOR FUERON " +
                                "EFECTUADOS, REPARADOS E INSPECCIONADOS, DE ACUERDO AL MANUAL DE MANTENIMIENTO DEL FABRICANTE, Y SE APRUEBA PARA REGRESAR A SERVICIO EN CONDICIONES DE " +
                                "AERONAVEGABILIDAD.").FontSize(6);
                            tabla.Cell().Row(6).Column(1).ColumnSpan(3).BorderBottom(0.3f).PaddingLeft(7).Text("LOS DETALLES PERTINENTES A ESTOS TRABAJOS, SE ENCUENTRAN ARCHIVADOS EN ESTE TALLER AERONAUTICO " +
                                "AUTORIZADO BAJO LA ORDEN DE TRABAJO No. : OT-0217").FontSize(6);
                            tabla.Cell().Row(7).Column(1).ColumnSpan(3).AlignCenter().AlignMiddle().PaddingLeft(7).Text("CARLOS ESTEVEZ ESCORZA").FontSize(6);
                            tabla.Cell().Row(8).Column(1).ColumnSpan(3).AlignCenter().AlignMiddle().PaddingLeft(7).Text("TECNICO AERONAUTICO").FontSize(6);
                            tabla.Cell().Row(9).Column(1).ColumnSpan(3).BorderBottom(0.3f).AlignCenter().AlignMiddle().PaddingLeft(7).Text("LIC 200003155\r\n").FontSize(6);



                        });

                    });
                });
            });
            Documento.ShowInPreviewer();
        }

        public void StikersEASAMotor(string Imagen)
        {
            var Documento = Document.Create(contenido =>
            {
                contenido.Page(pagina =>
                {
                    pagina.Margin(120);
                    pagina.Content().Column(columna =>
                    {
                        columna.Item().Border(2).PaddingTop(5).Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Height(40).PaddingTop(5).PaddingBottom(2).Image(Imagen).FitHeight();
                        });


                        columna.Item().BorderVertical(2).Column(columna =>
                        {
                            columna.Item().AlignCenter().Text("TALLER AUTORIZADO D.G.A.C. No. 398").Bold().FontSize(9);
                            columna.Item().AlignCenter().Text("AEROPUERTO NACIONAL PACHUCA HGO HANGAR 14 TEL (771) 7915594").FontSize(7);
                        });


                        columna.Item().BorderVertical(2).Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().Column(1).Border(0.3f).AlignCenter().AlignMiddle().Text("").FontSize(8).Bold();
                            tabla.Cell().Column(2).Border(0.3f).PaddingLeft(7).Text("FECHA:").FontSize(8).Bold();

                        });

                        columna.Item().BorderVertical(2).BorderBottom(2).Border(0.3f).Table(tabla =>
                        {

                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            tabla.Cell().Row(1).Column(1).Border(0.3f).Background("#8FAADC").AlignCenter().PaddingLeft(7).Text("MOTOR").FontSize(8).Bold();
                            tabla.Cell().Row(1).Column(2).Border(0.3f).PaddingLeft(7).Text("T.T:    ----").FontSize(8).Bold();
                            tabla.Cell().Row(1).Column(3).Border(0.3f).PaddingLeft(7).Text("T.U.R.M:    ---").FontSize(8).Bold();

                            tabla.Cell().Row(2).Column(1).Border(0.3f).PaddingLeft(7).Text("MARCA:    -----").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(2).Border(0.3f).PaddingLeft(7).Text("MODELO:   ----").FontSize(8).Bold();
                            tabla.Cell().Row(2).Column(3).Border(0.3f).PaddingLeft(7).Text("SERIE:   ---").FontSize(8).Bold();

                            tabla.Cell().Row(3).Column(1).ColumnSpan(3).Background("#8FAADC").Border(0.3f).AlignCenter().AlignMiddle().Text("PLANEADOR").FontSize(8).Bold();

                            tabla.Cell().Row(4).Column(1).Border(0.3f).PaddingLeft(7).Text("MARCA:    -----").FontSize(8).Bold();
                            tabla.Cell().Row(4).Column(2).Border(0.3f).PaddingLeft(7).Text("MODELO:   ----").FontSize(8).Bold();
                            tabla.Cell().Row(4).Column(3).Border(0.3f).PaddingLeft(7).Text("SERIE:   ---").FontSize(8).Bold();

                            tabla.Cell().Row(5).Column(1).Border(0.3f).PaddingLeft(7).Text("MATRICULA:  -----").FontSize(8).Bold();
                            tabla.Cell().Row(5).Column(2).ColumnSpan(2).Border(0.3f).PaddingLeft(7).Text("TIPO: ----").FontSize(8).Bold();

                            tabla.Cell().Row(6).Column(1).ColumnSpan(3).Border(0.3f).Column(columna =>
                            {
                                columna.Item().PaddingLeft(7).Text("CON ESTA FECHA Y HORAS SE EFECTURAON LOS SIGUIENTES TRABAJOS DE MANTENIMIENTO:").FontSize(8);
                                columna.Item().Padding(15).Text(text =>
                                {
                                    text.ParagraphSpacing(2);
                                    text.Line("•  APLICACIÓN DE CARTA DE SERVICIO DE 100 HORAS").FontSize(8);
                                    text.Line("•  LUBRICACION DE CABLES Y POLEAS").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                    text.Line("•  INSPECCION A SUPERFICIES DE CONTROL").FontSize(8);
                                });
                            });

                            tabla.Cell().Row(7).Column(1).ColumnSpan(3).BorderTop(0.3f).PaddingLeft(7).Text("CERTIFICAMOS QUE LOS TRABAJOS ANTES MENCIONADOS EN LA AERONAVE, PLANEADOR FUERON " +
                                "EFECTUADOS, REPARADOS E INSPECCIONADOS, DE ACUERDO AL MANUAL DE MANTENIMIENTO DEL FABRICANTE, Y SE APRUEBA PARA REGRESAR A SERVICIO EN CONDICIONES DE " +
                                "AERONAVEGABILIDAD.").FontSize(6);
                            tabla.Cell().Row(8).Column(1).ColumnSpan(3).BorderBottom(0.3f).PaddingLeft(7).Text("LOS DETALLES PERTINENTES A ESTOS TRABAJOS, SE ENCUENTRAN ARCHIVADOS EN ESTE TALLER AERONAUTICO " +
                                "AUTORIZADO BAJO LA ORDEN DE TRABAJO No. : OT-0217").FontSize(6);
                            tabla.Cell().Row(9).Column(1).ColumnSpan(3).AlignCenter().AlignMiddle().PaddingLeft(7).Text("CARLOS ESTEVEZ ESCORZA").FontSize(6);
                            tabla.Cell().Row(10).Column(1).ColumnSpan(3).AlignCenter().AlignMiddle().PaddingLeft(7).Text("TECNICO AERONAUTICO").FontSize(6);
                            tabla.Cell().Row(11).Column(1).ColumnSpan(3).BorderBottom(0.3f).AlignCenter().AlignMiddle().PaddingLeft(7).Text("LIC 200003155\r\n").FontSize(6);



                        });

                    });
                });
            });
            Documento.ShowInPreviewer();
        }
    }
}
