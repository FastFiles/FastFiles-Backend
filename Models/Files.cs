
using FastFiles.Models; //este se genera por el modelo del enum

namespace FastFiles.Models{
    
    public class Files
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateOnly DateCreated {get; set;}
        public DateOnly DateModified {get; set;}
        //public Blob Data {get; set;}
        public enum FileStatus{
        Active,
        Inactive
    }
        public int UserId  {get; set;} 
        public User User {get; set;} //Usamos la relación de Modelos
        public int FolderId  {get; set;}
        public Folder Folder {get; set;} //Hace falta el modelo folder di mi estimado...


    }
}
