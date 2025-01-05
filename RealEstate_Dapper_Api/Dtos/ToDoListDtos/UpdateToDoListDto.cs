namespace RealEstate_Dapper_Api.Dtos.ToDoListDtos
{
    public class UpdateToDoListDto
    {
        public int ToDoListId { get; set; }
        public string ToDoContent { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
