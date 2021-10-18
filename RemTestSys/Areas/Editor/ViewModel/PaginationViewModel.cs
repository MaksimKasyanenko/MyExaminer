namespace RemTestSys.Areas.Editor.ViewModel
{
    public class PaginationViewModel
    {
        public int AllElementsCount{get;set;}
        public int CurrentPage{get;set;}
        public int ElementsPerPage{get;set;}
        public int CountOfPages
        {
            get
            {
                if(AllElementsCount<1)return 0;
                int res = AllElementsCount/ElementsPerPage;
                if(AllElementsCount%ElementsPerPage != 0)res++;
                return res;
            }
        }
        public int SkippedPages
        {
            get
            {
                return ElementsPerPage * (CurrentPage - 1);
            }
        }
    }
}