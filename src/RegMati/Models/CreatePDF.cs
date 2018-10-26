using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace RegMati.Models
{
    public class CreatePDF
    {
        public Rectangle p_size { get; set; }
        public float left { get; set; }
        public float right { get; set; }
        public float top { get; set; }
        public float buttom { get; set; }
        public BaseFont bf { get; set; }
        public string returnfile { get; set; }
        public FileStream fs { get; set; }
        public Document document { get; set; }
        public PdfPTable table { get; set; }
        public string[] header_name { get; set; }
        public PdfWriter writer { get; set; }
        public PdfReader reader { get; set; }

        public void step0_setPageSize(Rectangle p_size, float left, float right, float top, float buttom)
        {

            document = new iTextSharp.text.Document(p_size, left, right, top, buttom);

        }
        public void step1_setFont()
        {

            bf = BaseFont.CreateFont(System.IO.Path.Combine("wwwroot/lib/bootstrap/dist/fonts/THSarabunNew.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        }

        public void step2_setPathPdf(string path, string file_name)
        {
           //writer =  PdfWriter.GetInstance(document, new FileStream("~/"+path+"/"+file_name+".pdf", FileMode.Create));
             fs = new FileStream(System.IO.Path.Combine("wwwroot/"+ path + "/", file_name + ".pdf"), FileMode.Create);
            returnfile = file_name + ".pdf";

        }
       
        public void step3_open_document()
        {
           
           writer = PdfWriter.GetInstance(document, fs);
            // Open the document to enable you to write to the document
            document.Open();

        }
        public void step4_create_table(float[] num_column)
        {

            table = new PdfPTable(num_column);

        }
        public void finally_document_close()
        {
            document.Close();

        }
        public Font font_default(float font_size)
        {

            Font font = new Font(bf, font_size);

            return font;
        }
        public Font font_default_blue(float font_size)
        {

            Font font = new Font(bf, font_size, 0, new CmykColor(1f, 0f, 0f, 0.8f));

            return font;
        }
        public Font font_bold(float font_size)
        {

            Font font = new Font(bf, font_size, 1);

            return font;
        }
        public Font font_bold_blue(float font_size)
        {

            Font font = new Font(bf, font_size, 1, new CmykColor(1f,0.18f,0.0f,0.01f));

            return font;
        }
        public Font font_bold_blue_dark(float font_size)
        {

            Font font = new Font(bf, font_size, 1, new CmykColor(1f, 0f, 0f, 0.8f));

            return font;
        }
        public Font font_bold_white(float font_size)
        {

            Font font = new Font(bf, font_size, 1, new CmykColor(0f, 0f, 0f, 0f));

            return font;
        }
        public Font font_under_line(float font_size)
        {

            Font font = new Font(bf, font_size, 4);

            return font;
        }
        public string get_path_logo() {

          // string p_logo = System.IO.Path.Combine("BIWBACK/src/BIWBACK/wwwroot/images/biw_logo.JPG");E:\RegMati\src\RegMati\wwwroot\images\logo_ma.bmp
            string p_logo = System.IO.Path.Combine("RegMati/src/RegMati/wwwroot/images/header_ma.png");

            return p_logo;
        }
        public string get_path_logo_ks()
        {

            // string p_logo = System.IO.Path.Combine("BIWBACK/src/BIWBACK/wwwroot/images/biw_logo.JPG");E:\RegMati\src\RegMati\wwwroot\images\logo_ma.bmp
            string p_logo = System.IO.Path.Combine("RegMati/src/RegMati/wwwroot/images/header_ks.png");

            return p_logo;
        }
        public string get_path_logo_nd()
        {

            // string p_logo = System.IO.Path.Combine("BIWBACK/src/BIWBACK/wwwroot/images/biw_logo.JPG");E:\RegMati\src\RegMati\wwwroot\images\logo_ma.bmp
            string p_logo = System.IO.Path.Combine("RegMati/src/RegMati/wwwroot/images/header_nd.png");

            return p_logo;
        }
        public Image get_logo(float width, float height) {

         Image  logo =  Image.GetInstance(get_path_logo());

             logo.ScaleToFit(width, height );

            return logo; 
        }
        public Image get_logo_ks(float width, float height)
        {

            Image logo = Image.GetInstance(get_path_logo_ks());

            logo.ScaleToFit(width, height);

            return logo;
        }
        public Image get_logo_nd(float width, float height)
        {

            Image logo = Image.GetInstance(get_path_logo_nd());

            logo.ScaleToFit(width, height);

            return logo;
        }
        public string get_path_pay()
        {

            // string p_logo = System.IO.Path.Combine("BIWBACK/src/BIWBACK/wwwroot/images/biw_logo.JPG");E:\RegMati\src\RegMati\wwwroot\images\logo_ma.bmp
            string p_logo = System.IO.Path.Combine("RegMati/src/RegMati/wwwroot/images/pay_ma.png");

            return p_logo;
        }
        public Image get_logo_pay(float width, float height)
        {

            Image logo = Image.GetInstance(get_path_pay());

            logo.ScaleToFit(width, height);

            return logo;
        }

        public string bg_path() {

            string  bg = System.IO.Path.Combine("RegMati/src/RegMati/wwwroot/images/logo_ma.bmp");

            return bg;
        }
        public void get_bg() {

            PdfContentByte canvas = writer.DirectContent;
            Image image = Image.GetInstance(bg_path());
            image.ScaleAbsolute(1200, 1500);
            image.SetAbsolutePosition(0, 0);
            canvas.SaveState();
            PdfGState state = new PdfGState();
            state.FillOpacity = 0.6f;
            canvas.SetGState(state);
            canvas.AddImage(image);
            canvas.RestoreState();

        }
        public Phrase AddPhase(string txt, Font font) {

            Phrase ph = new Phrase();
            ph = new Phrase(txt,font);

            return ph;
        }
        public PdfPCell getCell(String text, int alignment, int colspan, int borderWidth, CmykColor bg, Font font, int rowspan, int top, int bottom, int left, int right, CmykColor border_color)
        {
            //PdfPCell cell = new PdfPCell(new Phrase(text, font));
            Phrase p = new Phrase();
            p.Add(new Paragraph(text, font));
            p.Add(new Paragraph("\n ", font_default(5f)));

            PdfPCell cell = new PdfPCell(p);

          

            cell.HorizontalAlignment = alignment;
            cell.BorderWidth = borderWidth;

            cell.BorderWidthTop = top;
            cell.BorderWidthBottom = bottom;
            cell.BorderWidthLeft = left;
            cell.BorderWidthRight = right;
           
            cell.Colspan = colspan;
            cell.Rowspan = rowspan;
            cell.BackgroundColor = bg;
            cell.BorderColor = border_color;

            return cell;
        }
        public Chunk get_new_line() {
            
            return Chunk.Newline;
        }
        public PdfPCell cellImg(Image img, int alignment, int borderWidth, int colspan, int rowspan, float padLeft, float padTop, int top, int bottom, int left, int right) {

            PdfPCell cell = new PdfPCell();
            cell.AddElement(img);
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = 1;
            cell.PaddingLeft = padLeft;
            cell.PaddingTop = padTop;
            cell.BorderWidth = borderWidth;

            cell.BorderWidthTop = top;
            cell.BorderWidthBottom = bottom;
            cell.BorderWidthLeft = left;
            cell.BorderWidthRight = right;

            cell.Colspan = colspan;
            cell.Rowspan = rowspan;


            return cell;
        }
        public PdfPTable get_header_logo() {
            
            PdfPCell cell = new PdfPCell();

            cell.AddElement(Chunk.Newline);
            cell.AddElement(get_logo(560f,100f));
  

            cell.BorderWidth = 0;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            cell.VerticalAlignment = 0;
             

            table.AddCell(cell); 

            return table;

        }
        public PdfPTable get_header_logo_ks()
        {

            PdfPCell cell = new PdfPCell();

            cell.AddElement(Chunk.Newline);
            cell.AddElement(get_logo_ks(560f, 100f));


            cell.BorderWidth = 0;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            cell.VerticalAlignment = 0;


            table.AddCell(cell);

            return table;

        }
        public PdfPTable get_header_logo_nd()
        {

            PdfPCell cell = new PdfPCell();

            cell.AddElement(Chunk.Newline);
            cell.AddElement(get_logo_nd(560f, 100f));


            cell.BorderWidth = 0;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            cell.VerticalAlignment = 0;


            table.AddCell(cell);

            return table;

        }
        public PdfContentByte frame(float width, float height) {
            
            float llx = 36;
            float ury = 806;
            PdfContentByte canvas = writer.DirectContentUnder;
            Rectangle rect1 = new Rectangle(llx,height,width,ury);
            rect1.EnableBorderSide(100);
            rect1.BackgroundColor = BaseColor.White;
            rect1.Border = Rectangle.BOX;
            rect1.BorderWidth = 1;
            canvas.Rectangle(rect1);
            
            return canvas;
        }
        




    }
}
