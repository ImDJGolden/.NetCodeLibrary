class x 
{
    DataTable dtasst = new DataTable();

    public void txtChanced(){
        dtAsst.DefaultView.RowFilter = String.Format($"asstArticleNumber LIKE '%{txtSearch.Text}%' OR asstArticleDescription LIKE '%{txtSearch.Text}%'");
    }
}