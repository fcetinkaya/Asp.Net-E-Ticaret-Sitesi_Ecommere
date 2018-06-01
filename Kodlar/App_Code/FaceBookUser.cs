using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FaceBookUser
/// </summary>
public class FaceBookUser : IDisposable
{

    public string Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string PictureUrl { get; set; }
    public string Email { get; set; }
    public string Birthday { get; set; }
    public string Gender { get; set; }
    public FaceBookEntity Location { get; set; }


    public class FaceBookEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}