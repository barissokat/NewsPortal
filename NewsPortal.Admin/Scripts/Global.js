function CreateCategory() {
    Category = new Object();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.Active = $("#categoryActive").is(":checked");

    $.ajax({
        url: "Category/Create",
        data: Category,
        type: "POST",
        success: function (response) {
            if (response.success) {
                alert("Başarılı işlemlerini yap.");
            }
            else {
                alert("Başarısız işlemlerini yap.")
            }
        }
    });
    
}