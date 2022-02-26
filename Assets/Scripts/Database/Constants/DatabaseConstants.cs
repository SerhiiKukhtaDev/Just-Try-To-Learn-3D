namespace Database.Constants
{
    public class DatabaseConstants
    {
        public const string DatabaseConnection = @"mongodb://Ram:6VmlQQx0ccXJho1p@cluster0-shard-00-00.zprr4.mongodb.net:27017,cluster0-shard-00-01.zprr4.mongodb.net:27017,cluster0-shard-00-02.zprr4.mongodb.net:27017/SubjectsDB?ssl=true&replicaSet=atlas-gquya2-shard-0&authSource=admin&retryWrites=true&w=majority";

        public const string DatabaseName = "SubjectsDB";

        public const string DatabaseSubjectsCollectionName = "SubjectsCollection";
    }
}
