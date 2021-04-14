using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Bdaya.Net.Blazor.FileUplodar
{
    public partial class FileUploader
    {
        [Parameter]
        public Func<InputFileChangeEventArgs, Task<string>> UploadToFileServer { get; set; }

        [Parameter]
        public EventCallback<string> OnUpload { get; set; }

        [Parameter] public string Width { get; set; } = "100%";
        [Parameter] public string Height { get; set; } = "15rem";


        private Guid _id = Guid.NewGuid();


        public string Image { get; set; }

        private async Task UploadFile(InputFileChangeEventArgs e)
        {
            var res =  await UploadToFileServer.Invoke(e);
            if (!string.IsNullOrEmpty(res))
            {
                Image = res;
                await OnUpload.InvokeAsync(Image);
            }
        }
    }
}
