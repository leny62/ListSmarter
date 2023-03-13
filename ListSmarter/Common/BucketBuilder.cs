using ListSmarter.Models;
using ListSmarter.Repositories.Models;
using Task = System.Threading.Tasks.Task;

namespace ListSmarter.Common;

public class BucketBuilder
{
   private int _id;
   private string _title;
   
   public BucketBuilder WithId(int id)
   {
      _id = id;
      return this;
   }
   
   public BucketBuilder WithTitle(string title)
   {
      _title = title;
      return this;
   }
   
   public Bucket Build()
   {
      return new Bucket
      {
         Id = _id,
         Title = _title
      };
   }
}