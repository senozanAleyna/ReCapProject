using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {


        public static string Add(IFormFile file)
        {
            //geçici path olusturuldu
            string sourcePath = Path.GetTempFileName();
            string destFileNameForDb = CreateNewFilePathForDB(file); //resmi aldık guid ile path oluşturduk
            string destFileNameForLocalFolder = CreateNewFilePathForLocalFolder(destFileNameForDb);
            //resmin pathini aldık dosya içine yerleştirdik

            if (file.Length > 0) //path kullanıldı dosyası oluşturuldu sonra bu dosyayı aşagıda nahi dosyaya taşıcaz
            {
                //belirtilen yol ve oluşturma moduyla sınıfın yeni bir örneğini başlatır
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);//Geçerli akıştan baytları okur ve bunları başka bir akışa yazar.
                }
            }

            File.Move(sourcePath, destFileNameForLocalFolder);//olusturmak istedigimiz dosyayi gecici adresten, nihai adresine tasimak uzere
            return destFileNameForDb;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            string pathForDb = CreateNewFilePathForDB(file);
            string pathForFolder = CreateNewFilePathForLocalFolder(pathForDb);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(pathForFolder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);//bize gönderilen eskisini siliyor
            return pathForDb;//images içindeki yeni yolu managera yolluyor
        }

        public static string CreateNewFilePathForDB(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);//bunu yapma amacımız bize gelen dosyanın uzantısını çekebilmektir.
            string fileExtension = fileInfo.Extension;//dosyanın uzantı bölümünü verir
            //Resimleri projemize atarken Guild metodunu kullanıyoruz.
            //bu bizim dosya ismimizi yüklerken random bir isimle kaydeder
            string newPath = Guid.NewGuid().ToString() + fileExtension; //iki yolu birleştirdik

            string result = $@"Images\{newPath}"; //Images klasoru+ içindeki fotonun numarası
            return result;
        }

        public static string CreateNewFilePathForLocalFolder(string pathForLocalFolder)
        {
            //buradaki path WebAPI'deki klasörün yolunu gösterir
            string path = Environment.CurrentDirectory + @"\wwwroot\" + pathForLocalFolder;
            return path;
        }


    }
}
