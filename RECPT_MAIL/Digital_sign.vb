Public Class Digital_sign
    Private Sub Digital_sign_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-------------------The code sample below creates a new signature field:

        ' Create a signature field on the first page:
        'Dim signatureFieldInfo = New PdfSignatureFieldInfo(1)

        '' Specify the field's name, location and rotation angle:
        'signatureFieldInfo.Name = "SignatureField"
        'signatureFieldInfo.SignatureBounds = New PdfRectangle(10, 10, 150, 150)
        'signatureFieldInfo.RotationAngle = PdfAcroFormFieldRotation.Rotate90

        ''------------------------The code sample below customizes the signature appearance:
        '' Apply a signature to an existing form field
        'Dim santuzzaSignature = New PdfSignatureBuilder(pkcs7Signature, "Sign")

        '' Specify an image and signer information
        'santuzzaSignature.Location = "Australia"
        'santuzzaSignature.Name = "Santuzza Valentina"
        'santuzzaSignature.Reason = "I Agree"

        '' Specify signature appearance parameters:
        'Dim signatureAppearance As New PdfSignatureAppearance()

        '' Add a signature image:
        'signatureAppearance.SetImageData("Signing Documents/logo.png")

        '' Specify what information to display:
        'signatureAppearance.ShowDate = True
        'signatureAppearance.ShowLocation = True

        '' Set display format for date and time:
        'signatureAppearance.DateTimeFormat = "mm/dd/yyyy"


        '' Change font settings for signature details:
        'signatureAppearance.SignatureDetailsFont.Size = 12
        'signatureAppearance.SignatureDetailsFont.Italic = True

        '' Apply changes:
        'santuzzaSignature.SetSignatureAppearance(signatureAppearance)
    End Sub
End Class