//using Microsoft.EntityFrameworkCore;
//using System;
//using tda_proj.Data;
//using tda_proj.Model;

//public class TagService
//{
//    public List<Tag> GetAllTags()
//    { 
//        using (tdaContext context = new tdaContext()) 
//        {
//            return context.Tags
//                .Include(lt => lt.LectorTag)
//                .ThenInclude(t => t.Tag)
//                .ToList();
//        }
    
//    }


//}
