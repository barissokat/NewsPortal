function CreateCategory() {
    Category = new Object();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.Active = $("#categoryActive").is(":checked");
    Category.ParentId = $("#ParentId").val();

    $.ajax({
        url: "/Category/Create",
        data: Category,
        type: "POST",
        dataType: 'json',
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                    //
                });
            }
        }
    });
}

$(".deleteCat").click(function () {
    var id = $(this).attr("data-id");
    var deletedRow = $(this).closest("tr");

    $.ajax({
        url: "/Category/Delete/" + id,
        type: "POST",
        dataType: "json",
        success: function (response) {
            if (response.Success) {
            $.notify(response.Message, "success");
            deletedRow.fadeOut(300, function () {
                deletedRow.remove();
            })
            }
            else {
                $.notify(response.Message, "error");
            }
        }
    })
});

function EditCategory() {
    Category = new Object();
    Category.ID = $("#categoryID").val();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.Active = $("#categoryActive").is(":checked");
    Category.ParentId = $("#ParentId").val();

    $.ajax({
        url: "/Category/Edit",
        data: Category,
        type: "POST",
        dataType: 'json',
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                    //
                });
            }
        }
    });
}