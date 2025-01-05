namespace RealEstate_Dapper_UI.Dtos.ToDoListDtos
{
    public class GetToDoListByIdDto
    {
        public int ToDoListId { get; set; }
        public string ToDoContent { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
