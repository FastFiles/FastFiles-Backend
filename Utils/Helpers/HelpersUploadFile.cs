using FastFiles.Providers; //Usamos la carpeta Providers.

namespace FastFiles.Helpers
{
    public class HelperUploadFiles
    {
        private PathProvider pathProvider; //Conexion de mi carpeta providers con la Helpers

        public HelperUploadFiles(PathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
        }

        public async Task<String> UploadFilesAsync(IFormFile formFile, string nombreImagen, Folders folder)
        {
            string path = this.pathProvider.MapPath(nombreImagen, folder);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return path;
        }
    }
}