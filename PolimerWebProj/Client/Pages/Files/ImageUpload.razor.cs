using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Files
{
    public partial class ImageUpload
    {
        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        private async Task UploadImage(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            foreach (var imageFile in imageFiles)
            {
                if (imageFile != null)
                {
                    var resizedFile = await imageFile.RequestImageFileAsync("image/png", 300, 500);
                    using (var ms = resizedFile.OpenReadStream(resizedFile.Size))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(resizedFile.Size)), "image", imageFile.Name);
                        var ImgResponse = await _httpRequestHandler.UploadImage(content, "static_file_handler/upload_static_file");
                        if (ImgResponse == "Image Path Exist")
                        {
                            _snackbar.Add("image with this name already exists", Severity.Warning);
                        }
                        else
                        {
                            _snackbar.Add("Image uploaded successfully.", Severity.Success);
                            await OnChange.InvokeAsync();
                        }
                    }
                }
            }

        }
    }
}
