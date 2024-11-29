using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using Registr8.Interfaces;

namespace Registr8.Interfaces
{
    class PickerInterface : IFilePickerService
    {
        public async Task<Dokumentum?> PickPdfFileAsync()
        {
            var pdftype = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                {DevicePlatform.iOS, new [] {"com.adobe.pdf" } },
                {DevicePlatform.Android, new[] {"application/pdf" } },
                {DevicePlatform.WinUI, new[] {".pdf" } }
            });
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Válassza ki a feltöltendő PDF fájlt",
                FileTypes = pdftype,
            });

            byte[] fileBytes;
            using (var stream = await result.OpenReadAsync())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
            }

            return new Dokumentum {
            FajlNev = result.FileName,
            ID = 0,
                ContentType = "application/pdf",
                bytes = fileBytes,
                base64 = Convert.ToBase64String(fileBytes)
            };
        }
    }
}
