namespace BookLibrary.App.Model
{
    public class ToastModel
    {
        public string? Message { get; set; }
        public TypeToast TypeToast { get; set; }

        public void DefineToast(string Message, TypeToast TypeToast)
        {
            this.Message = Message;
            this.TypeToast = TypeToast;
        }
    }
}
