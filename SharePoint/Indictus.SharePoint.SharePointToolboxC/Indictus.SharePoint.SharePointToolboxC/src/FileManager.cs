
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using System.IO;


namespace Indictus.SharePoint.SharePointToolboxC
{
    public class FileManager
    {
        public int UploadFileViaContentStream(ClientContext context, string sLibraryName, string sLocalFilePath)
        {
            try
            {
                Web web = context.Web;
                using (FileStream fs = new FileStream(sLocalFilePath, FileMode.Open))
                {
                    FileCreationInformation flciNewFile = new FileCreationInformation();             
                    flciNewFile.ContentStream = fs;
                    flciNewFile.Url = System.IO.Path.GetFileName(sLocalFilePath);
                    flciNewFile.Overwrite = true;
                    
                    List docs = web.Lists.GetByTitle(sLibraryName);
                    Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(flciNewFile);
                    
                    context.Load(uploadFile);
                    context.Load(uploadFile.ListItemAllFields);
                    context.ExecuteQuery();

                    return uploadFile.ListItemAllFields.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;        
            }            
        }
    }
}
