namespace IService
{
    public interface IMigration
    {
        /// <summary>
        /// 根据ID号转移数据
        /// </summary>
        /// <param name="id"></param>
        string MirgrationById(string id);

    }
}
