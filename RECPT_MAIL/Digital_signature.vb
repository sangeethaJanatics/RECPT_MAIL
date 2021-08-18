Imports Spire.Pdf
Imports Spire.Pdf.Security
Public Class Digital_signature
    Private Sub Digital_signature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim doc As PdfDocument = New PdfDocument("D:\I28 inv.pdf")
        Dim page As PdfPageBase = doc.Pages(0)
        'Dim cert As PdfCertificate = New PdfCertificate("Demo.pfx", "e-iceblue")
        Dim cert As PdfCertificate = New PdfCertificate("C:\Users\edp005\Downloads\Class 2 Docsigntest.pfx", "emudhra")


        'var signature = New PdfSignature(doc, doc.Pages[0], cert, "Requestd1");
        '    signature.Bounds = New RectangleF(New PointF(280, 600), New SizeF(260, 90));
        '    signature.IsTag = True;

        Dim signature As PdfSignature = New PdfSignature(doc, page, cert, "demo")
        signature.ContactInfo = "Harry"
        signature.Bounds = New Rectangle(New Point(280, 600), New Size(260, 90))
        signature.Certificated = True
        signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill
        doc.SaveToFile("d:\Result.pdf")

    End Sub

End Class