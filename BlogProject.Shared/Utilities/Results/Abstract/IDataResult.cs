namespace BlogProject.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }  //new DataResult<Category>(ResultStatus.Success,category);
                                //new DataResult<IList<Category>>(ResultStatus.Success,categoryList);
                                //burada hem entity hemde entity'nin listesi aynı yerden alınabilir hale getirilmektedir.
    }
}
