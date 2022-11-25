using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;


namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public string Add(IFormFile file, string root)
        {
            //Upload

            if (file.Length > 0) //Dosya uzunluğunu byte olarak alır.0'dan büyükse resim alınmıştır.
            {
                if (!Directory.Exists(root))
                {
                    //Path yoksa yarat
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); //Seçilen dosyanın uzantısını elde edilir.
                string guid = GuidHelper.GuidHelper.CreateGuid();
                string filePath = guid + extension; //Dosyanın adı ve uzantısı birleştirilir.

                using (FileStream fileStream = File.Create(root + filePath)) //root: Oluşturulacak dosyanın adı , filePath: Dosyanın adı
                {
                    file.CopyTo(fileStream); //Dosya nereye kopyalanacak ? 
                    fileStream.Flush(); //Arabellekten siler.
                    return filePath; //Dosyanun tam adı geri gönderilir çünkü sql server'a dosya eklenirken adı ile eklenmesi için.
                }
            }

            return null;

        }

        public void Delete(string filePath) //filePath, resmin direkt olarak adresidir.
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                //Hata yakalama güncellenecek
                Console.WriteLine("Dosya bulunamadığından silme işlemi yapılamadı.");
            }
            

        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Add(file, root);
        }
    }
}

/*
   IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
   FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar 
üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır
*/
