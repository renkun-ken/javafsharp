let [<Literal>] ikvm = @"..\packages\JavaTypeProvider.1.0.0\IKVM\bin\"
let [<Literal>] itextpdf = @"..\JavaSources\itextpdf-5.4.4.jar"
let [<Literal>] javaTest2 = @"..\JavaSources\javaTest2.jar"
let [<Literal>] scalaTest1 = @"..\JavaSources\scalaTest1.jar"

type iTextPdf = Java.JavaProvider<itextpdf,ikvm>
type javaTest2 = Java.JavaProvider<javaTest2,ikvm>
type scalaTest1 = Java.JavaProvider<scalaTest1,ikvm>

type iText = iTextPdf.com.itextpdf.text
type PDF = iTextPdf.com.itextpdf.text.pdf
type Main = javaTest2.Program
type Student = javaTest2.Student
type Building = javaTest2.Building
type SProgram = scalaTest1.Program

let createPDF (filename:string) (contents:string) =
    let document = new iText.Document();
    PDF.PdfWriter.getInstance(document,new java.io.FileOutputStream(filename)) |> ignore
    document.``open``()
    document.addTitle("Some Title") |> ignore
    document.add(new iText.Paragraph(contents)) |> ignore    
    document.close()

let createDemoPDF () =
    let fname = @"D:\Workspaces\javafsharp\output\test.pdf"
    createPDF fname "Hello, Java, from .NET"
    printfn "PDF written to %s" fname
    
[<EntryPoint>]
let main argv = 
    let s1 = Student()
    s1.Name <- "James"
    Main.main([|"arg1";"arg2";"arg3"|])
    let b1 = Building()
    let x1 = b1.getInfo(1,2)
    createDemoPDF()
    let scalaProgram = SProgram()
    scalaProgram.Main([|"hello";"scala"|])
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code