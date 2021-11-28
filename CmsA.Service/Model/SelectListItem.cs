

namespace CmsA.Service.Model;

public class SelectListItem
{
    public string Id { get; set; }
    public string Name { get; set; }

    public SelectListItem(string Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;   
    }
}

